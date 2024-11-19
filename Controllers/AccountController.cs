using System.Security.Claims;
using api.DTOs.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
    
    [HttpPost("register-admin")]
    public async Task<ActionResult> RegisterAdmin([FromBody] RegisterDto registerDto)
    {
        try
        {
            // Validate the incoming model
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            // Check if "Admin" role exists, and create it if not
            var adminRoleExists = await _roleManager.RoleExistsAsync("Admin");
            if (!adminRoleExists)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Admin"));
                if (!roleResult.Succeeded)
                {
                    var roleErrors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                    return StatusCode(500, $"Failed to create Admin role: {roleErrors}");
                }
            }

            // Create a new user instance
            var appUser = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };

            // Attempt to create the user
            var createUser = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!createUser.Succeeded)
            {
                var userErrors = string.Join(", ", createUser.Errors.Select(e => e.Description));
                return BadRequest($"Failed to create user: {userErrors}");
            }

            // Assign the user to the "Admin" role
            var roleAssignment = await _userManager.AddToRoleAsync(appUser, "Admin");
            if (!roleAssignment.Succeeded)
            {
                var roleAssignmentErrors = string.Join(", ", roleAssignment.Errors.Select(e => e.Description));
                return BadRequest($"Failed to add user to Admin role: {roleAssignmentErrors}");
            }
            
            await _userManager.AddClaimAsync(appUser, new Claim("Role", "Admin"));
            var role = await _roleManager.FindByNameAsync("Admin");
            if (role != null)
            {
                await _roleManager.AddClaimAsync(role, new Claim("Permission", "AdminAccess"));
            }

            return Ok("Admin Created Successfully");
        }
        catch (Exception e)
        {
            return StatusCode(500, $"An error occurred: {e.Message}");
        }
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var appUser = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };
            
            var createUser = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (createUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                if (roleResult.Succeeded)
                {
                    await _userManager.AddClaimAsync(appUser, new Claim("Role", "User"));
                    var role = await _roleManager.FindByNameAsync("Admin");
                    if (role != null)
                    {
                        await _roleManager.AddClaimAsync(role, new Claim("Permission", "UserAccess"));
                    }
                    return Ok("User Created");
                }
                else
                { 
                    return BadRequest(roleResult.Errors);
                }
            }
            else
            {
                return BadRequest(createUser.Errors);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var user = _userManager.Users.FirstOrDefault(x => x.UserName == loginDto.Username.ToLower());
        if(user == null) return Unauthorized("Invalid username!");
        
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded) return Unauthorized("Username or password is incorrect!");
        return Ok(new NewUserDto
        {
            Username = user.UserName!,
            Email = user.Email!,
            Token = await _tokenService.CreateToken(user)
        });
    }
}