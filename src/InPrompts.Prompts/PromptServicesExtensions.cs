using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Serilog;

namespace InPrompts.Prompts;

public static class PromptServicesExtensions
{
    public static IServiceCollection AddPromptModule(this IServiceCollection services, ConfigurationManager config, ILogger logger)
    {
        var connectionString = config.GetConnectionString("Prompts") ?? string.Empty;
        services.AddDbContext<PromptDbContext>(options => options.UseNpgsql(connectionString))
        .AddScoped<IPromptRepository, EfPromptRepository>()
        .AddScoped<IPromptService, PromptService>();

        logger.Information("{Module} module services registered", "Books");
        return services;
    }
}