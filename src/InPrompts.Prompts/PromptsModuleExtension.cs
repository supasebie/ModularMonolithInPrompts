using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using InPrompts.Prompts.Data;

using Serilog;
using AutoMapper;

namespace InPrompts.Prompts;

public static class PromptsModuleExtension
{
    public static IServiceCollection AddPromptModule(
        this IServiceCollection services,
        ConfigurationManager config,
        ILogger logger,
        List<Assembly> appAssemblies)
    {
        var connectionString = config.GetConnectionString("Prompts") ?? string.Empty;
        services.AddDbContext<PromptsDbContext>(options => options.UseNpgsql(connectionString))
        .AddScoped<IEfPromptRepository, EfPromptRepository>()
        .AddScoped<IPromptService, PromptService>();
        appAssemblies.Add(typeof(PromptsModuleExtension).Assembly);

        var mapperConfig = new MapperConfiguration(m =>
        {
            m.CreateMap<PromptResponseDto, Prompt>();
            m.CreateMap<Prompt, PromptResponseDto>();
            m.CreateMap<CreatePromptDto, Prompt>();
            m.CreateMap<Prompt, CreatePromptDto>();
        });

        logger.Information("{Module} module services registered", "Prompts");
        return services;
    }
}