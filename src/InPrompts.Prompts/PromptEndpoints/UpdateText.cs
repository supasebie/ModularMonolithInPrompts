using FastEndpoints;

namespace InPrompts.Prompts.PromptEndpoints;

public record UpdatePromptTextRequest
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;

    public UpdatePromptTextRequest(int id, string text)
    {
        Id = id;
        Text = text;
    }
}

internal class UpdatePromptText(IPromptService promptService) : Endpoint<UpdatePromptTextRequest, Prompt>
{
    public override void Configure()
    {
        Put("/prompt/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdatePromptTextRequest request, CancellationToken ct)
    {
        await promptService.UpdatePromptAsync(request.Id, request.Text);
        await SendNoContentAsync(cancellation: ct);
    }
}