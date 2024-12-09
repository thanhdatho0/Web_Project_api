using api.DTOs.Token;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController(ITokenService tokenService) : ControllerBase
{
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh()
    {
        var refreshToken = Request.Cookies["RefreshToken"];
        if (string.IsNullOrEmpty(refreshToken))
        {
            return Unauthorized("Refresh token is missing.");
        }

        var accessToken = Request.Headers.Authorization.ToString().Replace("Bearer ", "");
        var tokenDto = new TokenDto { AccessToken = accessToken, RefreshToken = refreshToken };
        try
        {
            var token = await tokenService.RefreshToken(tokenDto);
            return Ok(token);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized("Invalid or expired token");
        }
    }
}