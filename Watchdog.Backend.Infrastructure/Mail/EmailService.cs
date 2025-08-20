using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Watchdog.Backend.Application.Contracts.Infrastructure;
using Watchdog.Backend.Application.Models.Mail;

namespace Watchdog.Backend.Infrastructure.Mail;

public class EmailService (IOptions<EmailSettings> mailSettings)
    : IEmailService
{
    private readonly EmailSettings _emailSettings = mailSettings.Value;
    
    public async Task<bool> SendEmailAsync(Email email)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        
        var to = new EmailAddress(email.To);
        var from = new EmailAddress(_emailSettings.FromAddress, _emailSettings.FromName);
        var subject = email.Subject;
        var emailBody = email.Body;
        
        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
        var response = await client.SendEmailAsync(sendGridMessage);

        return response.IsSuccessStatusCode;
    }
}