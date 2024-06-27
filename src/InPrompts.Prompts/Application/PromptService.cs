using Ardalis.Result;

using AutoMapper;

namespace InPrompts.Prompts;

internal class PromptService(IEfPromptRepository repo, IMapper mapper) : IPromptService
{
    private readonly IMapper _mapper = mapper;

    public async Task<Result<PromptResponseDto>> CreatePromptAsync(CreatePromptDto newPrompt)
    {
        var prompt = new Prompt
        {
            UserEmail = newPrompt.UserEmail,
            PostTitle = newPrompt.PostTitle,
            PostBodyText = newPrompt.PostBodyText,
            PromptText = newPrompt.PromptText,
            ReferenceMaterialImageUrl = newPrompt.ReferenceMaterialImageUrl,
            ReferenceMaterialText = newPrompt.ReferenceMaterialText,
            PromptResultImageUrl = newPrompt.PromptResultImageUrl,
            PromptResultText = newPrompt.PromptResultText,
        };

        await repo.AddAsync(prompt);
        await repo.SaveChangesAsync();

        var response = _mapper.Map<PromptResponseDto>(prompt);
        return response;
    }

    public async Task DeletePromptAsync(int id)
    {
        var promptToDelete = await repo.GetByIdAsync(id);
        await repo.RemoveAsync(promptToDelete!);
        await repo.SaveChangesAsync();
    }

    public async Task<Prompt> GetPromptByIdAsync(int id)
    {
        return await repo.GetByIdAsync(id) switch
        {
            null => throw new KeyNotFoundException($"Prompt with id {id} not found"),
            var prompt => prompt
        };
    }

    public async Task<List<Prompt>> ListPromptsAsync()
    {
        var prompts = await repo.ListAsync();
        return prompts.Select(prompt => new Prompt
        {
            Id = prompt.Id,
            UserEmail = prompt.UserEmail,
            PostTitle = prompt.PostTitle,
            PostBodyText = prompt.PostBodyText,
            PromptText = prompt.PromptText,
            ReferenceMaterialImageUrl = prompt.ReferenceMaterialImageUrl,
            ReferenceMaterialText = prompt.ReferenceMaterialText,
            PromptResultImageUrl = prompt.PromptResultImageUrl,
            PromptResultText = prompt.PromptResultText,
            UpVotes = prompt.UpVotes,
            DownVotes = prompt.DownVotes,
            ViewCount = prompt.ViewCount
        }).ToList();
    }

    public async Task UpdatePromptAsync(int id, string newText)
    {
        var prompt = await repo.GetByIdAsync(id);
        prompt!.UpdateText(newText);
        await repo.SaveChangesAsync();
    }
}
