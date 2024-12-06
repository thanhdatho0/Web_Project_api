using api.DTOs.Token;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Interfaces;

public interface ITokenService
{
    Task<TokenDto> CreateToken(AppUser user, bool populateExp);
    Task<TokenDto> RefreshToken(TokenDto tokenDto);
}