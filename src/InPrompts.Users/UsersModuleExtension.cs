using System.Reflection;

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
    List<Assembly> assemblies)
    {
        var connectionString = configuration.GetConnectionString("Users");
        services.AddDbContext<UsersDbContext>(config => config.UseNpgsql(connectionString));
        services.AddIdentityCore<AppUser>()
            .AddEntityFrameworkStores<UsersDbContext>();
        assemblies.Add(typeof(UsersModuleExtension).Assembly);
        services.AddScoped<IEfUserRepository, EfUserRepository>();



        return services;
    }
}

