using System.Net;
using System.Net.Mail;
using System.Text;
using api.Interfaces;
using api.Models;

namespace api.Services;

public class EmailService : IEmailService
{
    public async Task<string> SendEmailAsync(EmailRequest emailRequest)
    {
        try
        {
            var newPassword = GenerateNewPassword();
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("webshoppn10@gmail.com", "wygy evem mepv ccrl"),
                EnableSsl = true
            };            
            var mailMessage = new MailMessage
            {
                From = new MailAddress("webshoppn10@gmail.com"),
                Subject = "Reset Password",
                Body = "Password mới. Vui lòng không tiết lộ: " + newPassword,
                IsBodyHtml = true
            }; 
            mailMessage.To.Add(emailRequest.Email);
            await smtpClient.SendMailAsync(mailMessage);
            return newPassword;
        }
        catch (SmtpException smtpEx)
        {
            throw new InvalidOperationException("SMTP error occurred", smtpEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to send email", ex);
        }
    }

    private static string GenerateNewPassword()
    {
        const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
        const string digits = "0123456789";
        const string specialChars = "!@#$%^&*()-_=+[]{}|;:',.<>?/";

        // Ensure at least one character from each set is included
        var random = new Random();
        var password = new StringBuilder();
        password.Append(upperCase[random.Next(upperCase.Length)]);
        password.Append(lowerCase[random.Next(lowerCase.Length)]);
        password.Append(digits[random.Next(digits.Length)]);
        password.Append(specialChars[random.Next(specialChars.Length)]);

        // Fill the remaining length with a random mix of all characters
        const string allChars = upperCase + lowerCase + digits + specialChars;
        while (password.Length < 8)
        {
            password.Append(allChars[random.Next(allChars.Length)]);
        }
        // Shuffle the password to make it more random
        return new string(password.ToString().OrderBy(_ => random.Next()).ToArray());
    }
}