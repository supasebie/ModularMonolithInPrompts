using System.Reflection;

using Microsoft.EntityFrameworkCore;

namespace InPrompts.Prompts.Data;

public class PromptsDbContext(DbContextOptions<PromptsDbContext> options) : DbContext(options)
{
  internal DbSet<Prompt> Prompts { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema(nameof(Prompts));
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.EnableDetailedErrors().EnableSensitiveDataLogging();
  }
}