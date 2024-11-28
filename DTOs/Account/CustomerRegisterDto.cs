using System.ComponentModel.DataAnnotations;
using api.DTOs.Customer;

namespace api.DTOs.Account;

public class CustomerRegisterDto
{
    public CustomerCreateDto CustomerInfo { get; set; } = new CustomerCreateDto();
    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;
}