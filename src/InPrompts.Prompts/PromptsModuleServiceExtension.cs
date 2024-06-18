using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using InPrompts.Prompts.Data;

using Serilog;

namespace InPrompts.Prompts;

public static class PromptsModuleServiceExtension
{
    public static IServiceCollection AddPromptModule(
        this IServiceCollection services,
        ConfigurationManager config,
        ILogger logger,
        List<Assembly> mediatrAssemblies)
    {
        var connectionString = config.GetConnectionString("Prompts") ?? string.Empty;
        services.AddDbContext<PromptsDbContext>(options => options.UseNpgsql(connectionString))
        .AddScoped<IEfPromptRepository, EfPromptRepository>()
        .AddScoped<IPromptService, PromptService>();
        mediatrAssemblies.Add(typeof(PromptsModuleServiceExtension).Assembly);

        logger.Information("{Module} module services registered", "Prompts");
        return services;
    }
}