
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Customer;

public class CustomerCreateDto
{
    public required CustomerPersonalInfo PersonalInfo { get; set; }
    [EmailAddress(ErrorMessage = "Email is required")]
    public string Email { get; set; } = string.Empty;
}