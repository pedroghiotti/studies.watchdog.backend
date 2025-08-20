using Microsoft.Extensions.DependencyInjection;

namespace Watchdog.Backend.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(c => { }, AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(c =>
            c.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
        );

        return services;
    }
}