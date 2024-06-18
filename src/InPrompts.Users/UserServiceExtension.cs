using System.Reflection;

using InPrompts.SharedKernel;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Serilog;

namespace InPrompts.Users;

public static class UserModuleServiceExtension
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
        mediatrAssemblies.Add(typeof(UserModuleServiceExtension).Assembly);
        services.AddScoped<IEfUserRepository, EfUserRepository>();

        logger.Information("{Module} module services registered", "Users");

        return services;
    }
}

public class AppRole : IdentityRole<int> { }

public class UsersDbContext(DbContextOptions<UsersDbContext> options, IDomainEventDispatcher? dispatcher) : IdentityDbContext<AppUser, AppRole, int>(options)
{
    public DbSet<AppUser> AppUsers { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("Users");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        if (dispatcher == null)
        {
            return result;
        }

        var entitiesWithEvents = (ChangeTracker.Entries<IHaveDomainEvents>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any()))
            .ToArray();
        await dispatcher.DispatchAndClearEventsAsync(entitiesWithEvents);
        return result;
    }
}