
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Customer;

public class CustomerCreateDto
{
    public CustomerPersonalInfo PersonalInfo { get; set; }
    [EmailAddress(ErrorMessage = "Email is required")]
    public string Email { get; set; } = string.Empty;
}