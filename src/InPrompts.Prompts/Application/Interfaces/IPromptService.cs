using Ardalis.Result;

namespace InPrompts.Prompts;

internal interface IPromptService
{
  Task<List<Prompt>> ListPromptsAsync();
  Task<Prompt> GetPromptByIdAsync(int id);
  Task<Result<PromptResponseDto>> CreatePromptAsync(CreatePromptDto newPrompt);
  Task DeletePromptAsync(int id);
  Task UpdatePromptAsync(int id, string newText);
}
