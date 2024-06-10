namespace InPrompts.Prompts;

internal class PromptService(IPromptRepository repo) : IPromptService
{
    public async Task CreatePromptAsync(PromptDto newPrompt)
    {
        var prompt = new Prompt(newPrompt.Id, newPrompt.Text, newPrompt.User, 0);
        await repo.AddAsync(prompt);
        await repo.SaveChangesAsync();
    }

    public async Task DeletePromptAsync(Guid id)
    {
        var promptToDelete = await repo.GetByIdAsync(id);
        await repo.RemoveAsync(promptToDelete!);
        await repo.SaveChangesAsync();
    }

    public async Task<PromptDto> GetPromptByIdAsync(Guid id)
    {
        return await repo.GetByIdAsync(id) switch
        {
            null => throw new KeyNotFoundException($"Prompt with id {id} not found"),
            var prompt => new PromptDto(prompt.Id, prompt.Text, prompt.User, prompt.ViewCount)
        };
    }

    public async Task<List<PromptDto>> ListPromptsAsync()
    {
        var prompts = await repo.ListAsync();
        return prompts.Select(prompts => new PromptDto(prompts.Id, prompts.Text, prompts.User, prompts.ViewCount)).ToList();
    }

    public async Task UpdatePromptAsync(Guid id, string newText)
    {
        var prompt = await repo.GetByIdAsync(id);
        prompt!.UpdateText(newText);
        await repo.SaveChangesAsync();
    }
}
