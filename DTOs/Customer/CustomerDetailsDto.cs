namespace api.DTOs.Customer;

public class CustomerDetailsDto
{
    public string FullName { get; set; } = string.Empty;
    public bool Male { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public string? Email { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
}