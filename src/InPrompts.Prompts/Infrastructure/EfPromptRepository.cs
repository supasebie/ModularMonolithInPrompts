using Microsoft.EntityFrameworkCore;
using InPrompts.Prompts.Data;

namespace InPrompts.Prompts;

internal class EfPromptRepository(PromptsDbContext dbContext) : IEfPromptRepository
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

  public async Task<Prompt?> GetByIdAsync(int id) => await dbContext.Prompts.FindAsync(id);

  public async Task<List<Prompt>> ListAsync() => await dbContext.Prompts.ToListAsync();
}