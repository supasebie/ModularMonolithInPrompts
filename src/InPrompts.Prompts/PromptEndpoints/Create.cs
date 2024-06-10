using FastEndpoints;

namespace InPrompts.Prompts.PromptEndpoints;

public record CreatePromptRequest
{
    public Guid? Id { get; set; }
    public string User { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int ViewCount { get; set; } = 0;
}
internal class Create(IPromptService promptService) : Endpoint<CreatePromptRequest, PromptDto>
{
    public override void Configure()
    {
        Post("/prompts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePromptRequest request, CancellationToken ct)
    {
        var newPrompt = new PromptDto(request.Id ?? Guid.NewGuid(), request.User, request.Text, request.ViewCount);
        await promptService.CreatePromptAsync(newPrompt);
        await SendCreatedAtAsync<GetById>(new { newPrompt.Id }, newPrompt, cancellation: ct);
    }
}