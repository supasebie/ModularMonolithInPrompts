using Ardalis.Result;

namespace InPrompts.Prompts;

internal interface IPromptService
{
  Task<List<Prompt>> ListPromptsAsync();
  Task<Prompt> GetPromptByIdAsync(Guid id);
  Task<Result<Prompt>> CreatePromptAsync(Prompt newPrompt);
  Task DeletePromptAsync(Guid id);
  Task UpdatePromptAsync(Guid id, string newText);
}
