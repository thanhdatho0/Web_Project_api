
namespace api.DTOs.Customer;

public class CustomerDetailsDto
{
    public int CustomerId { get; set; }
    public CustomerPersonalInfo PersonalInfo { get; set; }
    public string? Email { get; set; } = string.Empty;
}