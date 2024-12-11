

using System.ComponentModel;

namespace api.DTOs.Customer;

public class CustomerDto
{
    public int CustomerId { get; set; }
    public CustomerPersonalInfo PersonalInfo { get; set; }
    public string? Email { get; set; }
    public string? Avatar { get; set; }
}