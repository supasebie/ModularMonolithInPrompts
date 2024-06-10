using FastEndpoints;

namespace InPrompts.Prompts.PromptEndpoints;

internal class List(IPromptService promptService) : EndpointWithoutRequest<ListPromptResponse>
{
    public override void Configure()
    {
        Get("/prompts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var prompts = await promptService.ListPromptsAsync();
        await SendAsync(new ListPromptResponse(prompts), cancellation: ct);
    }
}

internal record ListPromptResponse(List<PromptDto> Prompts);
