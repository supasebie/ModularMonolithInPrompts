using FastEndpoints;

namespace InPrompts.Prompts.PromptEndpoints;

public record UpdateTextRequest
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;

    public UpdateTextRequest(Guid id, string text)
    {
        Id = id;
        Text = text;
    }
}

internal class UpdateText(IPromptService promptService) : Endpoint<UpdateTextRequest, PromptDto>
{
    public override void Configure()
    {
        Put("/prompt/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateTextRequest request, CancellationToken ct)
    {
        await promptService.UpdatePromptAsync(request.Id, request.Text);
        await SendNoContentAsync(cancellation: ct);
    }
}