using System.Reflection;

using InPrompts.EventBus;

using Microsoft.EntityFrameworkCore;

namespace InPrompts.Prompts.Data;

public class SagaDbContext(DbContextOptions<SagaDbContext> options) : DbContext(options)
{
  internal DbSet<EmailNewUserSagaData> EmailSagas { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema(nameof(EventBus));
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    modelBuilder.Entity<EmailNewUserSagaData>().HasKey(s => s.CorrelationId);
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.EnableDetailedErrors().EnableSensitiveDataLogging();
  }
}