using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailSenderController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly UserManager<AppUser> _userManager;
    public EmailSenderController(IEmailService emailService, UserManager<AppUser> userManager)
    {
        _emailService = emailService;
        _userManager = userManager;
    }
    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] EmailRequest? request)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        if (request == null)
        {
            return BadRequest("Invalid email request");
        }
        var validUser = await _userManager.FindByEmailAsync(request.Email);
        if(validUser == null || validUser.UserName != request.Username)
            return StatusCode(500, "Email or Username is incorrect");
        try
        {
            var newPassword = await _emailService.SendEmailAsync(request);
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(validUser);
            await _userManager.ResetPasswordAsync(validUser, resetToken, newPassword);
            return Ok("Email sent successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}