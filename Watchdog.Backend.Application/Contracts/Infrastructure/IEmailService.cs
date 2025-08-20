using Watchdog.Backend.Application.Models;
using Watchdog.Backend.Application.Models.Mail;

namespace Watchdog.Backend.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmailAsync(Email email);
}