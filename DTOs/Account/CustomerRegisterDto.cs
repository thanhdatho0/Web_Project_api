using System.ComponentModel.DataAnnotations;
using api.DTOs.Customer;
using api.Models;

namespace api.DTOs.Account;

public class CustomerRegisterDto
{
    public required CustomerCreateDto CustomerInfo { get; set; }
    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; } = string.Empty;
}