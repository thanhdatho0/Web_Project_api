using System.ComponentModel.DataAnnotations;
using api.DTOs.Customer;

namespace api.DTOs.Account;

public class NewUserDto
{
    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Token is required.")]
    public string Token { get; set; } = string.Empty;
}