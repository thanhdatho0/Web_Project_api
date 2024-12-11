
namespace api.DTOs.Customer;

public class CustomerDetailsDto
{
    public required CustomerPersonalInfo PersonalInfo { get; set; }
    public string? Email { get; set; } = string.Empty;
}