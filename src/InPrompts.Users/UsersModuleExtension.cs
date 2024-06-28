using System.Reflection;

using InPrompts.SharedKernel;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Serilog;

namespace InPrompts.Users;

public static class UsersModuleExtension
{
    public static IServiceCollection AddUserModule(
    this IServiceCollection services,
    IConfiguration configuration,
    ILogger logger,
    List<Assembly> mediatrAssemblies)
    {
        var connectionString = configuration.GetConnectionString("Users");
        services.AddDbContext<UsersDbContext>(config => config.UseNpgsql(connectionString));
        services.AddIdentityCore<AppUser>()
            .AddEntityFrameworkStores<UsersDbContext>();
        mediatrAssemblies.Add(typeof(UsersModuleExtension).Assembly);
        services.AddScoped<IEfUserRepository, EfUserRepository>();

        logger.Information("{Module} module services registered", "Users");

        return services;
    }
}

