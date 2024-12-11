
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace api.Models;

public class AppUser : IdentityUser
{
    [DefaultValue("")]
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiryTime{ get; set; }
    public DateTime AccessTokenExpiryTime { get; set; }
}