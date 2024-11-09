using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Account;

public class NewUserDto
{
    [Required] 
    public string Username { get; set; }
    [Required] 
    public string Email { get; set; }
    [Required] 
    public string Token { get; set; }
}