using System.Reflection;

using InPrompts.SharedKernel;
using InPrompts.User;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

namespace InPrompts.Users;

public class UsersDbContext(DbContextOptions<UsersDbContext> options, IDomainEventDispatcher? dispatcher) : IdentityDbContext<AppUser, AppRole, Guid>(options)
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

    var entitiesWithEvents = ChangeTracker.Entries<IHaveDomainEvents>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
        .ToArray();
    await dispatcher.DispatchAndClearEventsAsync(entitiesWithEvents);
    return result;
  }
}