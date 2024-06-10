using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InPrompts.Prompts;

public class PromptDbContext(DbContextOptions options) : DbContext(options)
{
    internal DbSet<Prompt> Prompts { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(nameof(Prompts));
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

internal class PromptConfiguration : IEntityTypeConfiguration<Prompt>
{
    public void Configure(EntityTypeBuilder<Prompt> builder)
    {
        builder.Property(t => t.Text).HasMaxLength(DataSchemaConstants.TEXT_MAX_LENGTH);
        builder.HasData(GetSamplePromptsData());
    }

    internal static readonly Guid Prompt1Id = new("DFFE455B-8F20-4B08-9EC5-3B4A1FFC4D18");
    internal static readonly Guid Prompt2Id = new("F8E9B841-E4AD-45ED-A68C-04E5EDD375FC");
    internal static readonly Guid Prompt3Id = new("BBB5A494-3CED-4E39-9BC9-59E1AC8123A1");

    private IEnumerable<Prompt> GetSamplePromptsData()
    {
        yield return new Prompt(Prompt1Id, "What is your favorite color?", "Daniel", 13);
        yield return new Prompt(Prompt2Id, "What is your favorite food?", "Dom", 13);
        yield return new Prompt(Prompt3Id, "What is your favorite movie?", "Soren", 2);
    }
}

public static class DataSchemaConstants
{
    public const int TEXT_MAX_LENGTH = 5000;
}

internal interface IPromptService
{
    Task<List<PromptDto>> ListPromptsAsync();
    Task<PromptDto> GetPromptByIdAsync(Guid id);
    Task CreatePromptAsync(PromptDto newPrompt);
    Task DeletePromptAsync(Guid id);
    Task UpdatePromptAsync(Guid id, string newText);
}

internal interface IReadOnlyPromptRepository
{
    Task<Prompt?> GetByIdAsync(Guid id);
    Task<List<Prompt>> ListAsync();
}

internal interface IPromptRepository : IReadOnlyPromptRepository
{
    Task AddAsync(Prompt newPrompt);
    Task RemoveAsync(Prompt promptToDelete);
    Task SaveChangesAsync();
}

internal class EfPromptRepository(PromptDbContext dbContext) : IPromptRepository
{
    public Task AddAsync(Prompt newPrompt)
    {
        dbContext.AddAsync(newPrompt);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Prompt promptToDelete)
    {
        dbContext.Remove(promptToDelete);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync() => dbContext.SaveChangesAsync();

    public async Task<Prompt?> GetByIdAsync(Guid id) => await dbContext.Prompts.FindAsync(id);

    public async Task<List<Prompt>> ListAsync() => await dbContext.Prompts.ToListAsync();
}
