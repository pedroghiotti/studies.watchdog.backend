using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Watchdog.Backend.Application.Contracts.Infrastructure;
using Watchdog.Backend.Application.Models.Mail;
using Watchdog.Backend.Infrastructure.Mail;

namespace Watchdog.Backend.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailService, EmailService>();
        
        return services;
    }
}