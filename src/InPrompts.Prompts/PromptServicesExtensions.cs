using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InPrompts.Prompts;

public static class PromptServicesExtensions
{
    public static IServiceCollection AddPromptServices(this IServiceCollection services, ConfigurationManager config)
    {
        var connectionString = config.GetConnectionString("Prompts") ?? string.Empty;
        return services.AddDbContext<PromptDbContext>(options => options.UseNpgsql(connectionString))
            .AddScoped<IPromptRepository, EfPromptRepository>()
            .AddScoped<IPromptService, PromptService>();
    }
}