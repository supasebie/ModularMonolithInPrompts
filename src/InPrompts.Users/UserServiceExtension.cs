using System.Reflection;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Serilog;

namespace InPrompts.Users;

public static class UserServiceExtensions
{
    public static IServiceCollection AddUserModuleServices(
    this IServiceCollection services,
    IConfiguration configuration,
    ILogger logger)
    {
        var connectionString = configuration.GetConnectionString("Users");
        services.AddDbContext<UsersDbContext>(config => config.UseNpgsql(connectionString));
        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<UsersDbContext>();

        logger.Information("{Module} module services registered", "Users");

        return services;
    }
}


public class ApplicationUser : IdentityUser<Guid> { }

public class ApplicationRole : IdentityRole<Guid> { }

public class UsersDbContext(DbContextOptions<UsersDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
    public DbSet<ApplicationUser> ApplicationUsers { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("Users");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    } 
}