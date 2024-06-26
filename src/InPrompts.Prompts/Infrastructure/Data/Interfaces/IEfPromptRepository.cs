namespace InPrompts.Prompts;

internal interface IEfPromptRepository : IReadOnlyPromptRepository
{
  Task AddAsync(Prompt newPrompt);
  Task RemoveAsync(Prompt promptToDelete);
  Task SaveChangesAsync();
}

internal interface IReadOnlyPromptRepository
{
  Task<Prompt?> GetByIdAsync(Guid id);
  Task<List<Prompt>> ListAsync();
}