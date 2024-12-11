using System.ComponentModel;

namespace api.DTOs.Customer;

public class CustomerUpdateDto
{
    public required CustomerPersonalInfo PersonalInfo { get; set; }
    [DefaultValue("")]
    public required string Email { get; set; }
}