namespace api.DTOs.Customer;

public class CustomerDto
{
    public string FullName { get; set; } = string.Empty;
    public bool Male { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? Avatar { get; set; }
}