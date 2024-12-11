

namespace api.DTOs.Customer;

public class CustomerDto
{
    public required CustomerPersonalInfo PersonalInfo { get; set; }
    public string? Email { get; set; }
    public string? Avatar { get; set; }
}