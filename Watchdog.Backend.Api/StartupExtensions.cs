using Watchdog.Backend.Application;
using Watchdog.Backend.Infrastructure;
using Watchdog.Backend.Persistence;

namespace Watchdog.Backend.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);

        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
            options.AddPolicy(
                "open",
                policy => policy.WithOrigins([
                    builder.Configuration["ApiUrl"] ?? "https://localhost:7020",
                    builder.Configuration["FrontendUrl"] ?? "https://localhost:7080"
                ])
                .AllowAnyMethod()
                .SetIsOriginAllowed(_ => true)
                .AllowAnyHeader()
                .AllowCredentials()
            )
        );

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseCors("open");
        app.UseHttpsRedirection();
        app.MapControllers();
        
        return app;
    }
}