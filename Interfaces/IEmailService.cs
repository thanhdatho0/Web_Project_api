using api.Models;

namespace api.Interfaces;

public interface IEmailService
{
    Task<string> SendEmailAsync(EmailRequest emailRequest);
}