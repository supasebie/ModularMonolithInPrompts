using Ardalis.Result;

namespace InPrompts.Prompts;

internal class PromptService(IEfPromptRepository repo) : IPromptService
{
    public async Task<Result<Prompt>> CreatePromptAsync(Prompt newPrompt)
    {
        var prompt = new Prompt
        {
            UserEmail = newPrompt.UserEmail,
            Title = newPrompt.Title,
            Body = newPrompt.Body,
            Text = newPrompt.Text,
            ReferenceImageUrl = newPrompt.ReferenceImageUrl,
            ImageResultUrl = newPrompt.ImageResultUrl,
            ReferenceText = newPrompt.ReferenceText,
            TextResult = newPrompt.TextResult
        };

        await repo.AddAsync(prompt);
        await repo.SaveChangesAsync();
        return prompt;
    }

    public async Task DeletePromptAsync(Guid id)
    {
        var promptToDelete = await repo.GetByIdAsync(id);
        await repo.RemoveAsync(promptToDelete!);
        await repo.SaveChangesAsync();
    }

    public async Task<Prompt> GetPromptByIdAsync(Guid id)
    {
        return await repo.GetByIdAsync(id) switch
        {
            null => throw new KeyNotFoundException($"Prompt with id {id} not found"),
            var prompt => new Prompt()
            {
                Id = prompt.Id,
                UserEmail = prompt.UserEmail,
                Title = prompt.Title,
                Body = prompt.Body,
                Text = prompt.Text,
                ReferenceImageUrl = prompt.ReferenceImageUrl,
                ImageResultUrl = prompt.ImageResultUrl,
                ReferenceText = prompt.ReferenceText,
                TextResult = prompt.TextResult,
                UpVotes = prompt.UpVotes,
                DownVotes = prompt.DownVotes,
                ViewCount = prompt.ViewCount
            }
        };
    }

    public async Task<List<Prompt>> ListPromptsAsync()
    {
        var prompts = await repo.ListAsync();
        return prompts.Select(prompt => new Prompt
        {
            Id = prompt.Id,
            UserEmail = prompt.UserEmail,
            Title = prompt.Title,
            Body = prompt.Body,
            Text = prompt.Text,
            ReferenceImageUrl = prompt.ReferenceImageUrl,
            ImageResultUrl = prompt.ImageResultUrl,
            ReferenceText = prompt.ReferenceText,
            TextResult = prompt.TextResult,
            UpVotes = prompt.UpVotes,
            DownVotes = prompt.DownVotes,
            ViewCount = prompt.ViewCount
        }).ToList();
    }

    public async Task UpdatePromptAsync(Guid id, string newText)
    {
        var prompt = await repo.GetByIdAsync(id);
        prompt!.UpdateText(newText);
        await repo.SaveChangesAsync();
    }
}
