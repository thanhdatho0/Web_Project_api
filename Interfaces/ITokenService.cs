using api.DTOs.Token;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Interfaces;

public interface ITokenService
{
    Task<TokenDto> CreateToken(AppUser user, bool populateExp);
    Task<string?> AddTokenToUser(IdentityUserToken<string> user);
    Task<bool> HasLoginBefore(string id);
    Task<TokenDto> RefreshToken(TokenDto tokenDto);
}