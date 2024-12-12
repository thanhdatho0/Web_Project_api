using System.ComponentModel;

namespace api.Models;

public class EmailRequest
{
    public string Username { get; set; } = string.Empty;
    [DefaultValue("")]
    public required string Email { get; set; }
}