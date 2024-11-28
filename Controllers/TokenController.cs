using api.DTOs.Token;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController(ITokenService tokenService) : ControllerBase
{
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        var token = await tokenService.RefreshToken(tokenDto);
        return Ok(token);
    }
}