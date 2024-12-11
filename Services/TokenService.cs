using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using api.Data;
using api.DTOs.Token;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace api.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;
    private readonly UserManager<AppUser> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TokenService(IConfiguration config, UserManager<AppUser> userManager, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _config = config;
        _userManager = userManager;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SigningKey"]!));
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<TokenDto> CreateToken(AppUser user, bool populateExp)
    {
        var userRoles = await _userManager.GetRolesAsync(user);
        var roleClaims = userRoles.Select(role => new Claim(ClaimTypes.Role, role));
        var claims = new List<Claim>
        {
            // new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            // new Claim(JwtRegisteredClaimNames.GivenName, user.UserName!),
            // new Claim(ClaimTypes.NameIdentifier, user.Id)
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName ?? ""),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Unique token ID
            new Claim("given_name", user.UserName ?? ""), // Add 'given_name' claim
            new Claim("nameid", user.Id), // User ID claim
        };
        
        claims.AddRange(roleClaims);
        
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30), // Thời gian hết hạn của Access Token
            SigningCredentials = creds,
            Issuer = _config["Jwt:Issuer"],
            Audience = _config["Jwt:Audience"],
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        
        var token = tokenHandler.CreateToken(tokenDescriptor);

        var refreshToken = GenerateRefreshToken();
        
        user.RefreshToken = refreshToken;
        if (populateExp)
        {
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            user.AccessTokenExpiryTime = DateTime.UtcNow.AddMinutes(30);
        }
        
        await _userManager.UpdateAsync(user);
        var accessToken = tokenHandler.WriteToken(token);

        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = user.RefreshTokenExpiryTime,
        };
        _httpContextAccessor.HttpContext?.Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        
        var existingToken = await _userManager.GetAuthenticationTokenAsync(user, "Default", "RefreshToken");
        if(string.IsNullOrEmpty(existingToken))
        {
            await _userManager.SetAuthenticationTokenAsync(user, "Default", "RefreshToken", user.RefreshToken);
        }
        return new TokenDto
        {   
            AccessToken = accessToken,
        };
    }

    public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
    {
        var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
        var user = await _userManager.FindByNameAsync(principal.Identity!.Name!);
        Console.WriteLine(user!.RefreshToken);
        Console.WriteLine(tokenDto.RefreshToken);
        if (user is null ||
            user.RefreshToken != tokenDto.RefreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.UtcNow || user.AccessTokenExpiryTime <= DateTime.UtcNow)
        {
            Console.WriteLine("Sai gì đó");
            throw new UnauthorizedAccessException();
        }
        user.AccessTokenExpiryTime = DateTime.UtcNow.AddMinutes(30);
        
        await _userManager.UpdateAsync(user);
        return await CreateToken(user, populateExp: false);
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = _config["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = _config["Jwt:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SigningKey"]!)),
            ValidateLifetime = false,
            NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname",
            RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            Console.WriteLine($"Identity Name: {principal.Identity?.Name}");
            var jwtSecurityToken = securityToken as JwtSecurityToken;
    
            if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg
                    .Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Token validation failed: {ex.Message}");
            throw;
        }
        //
        // return principal;
    }

}