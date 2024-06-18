using FastEndpoints;

namespace InPrompts.Prompts.PromptEndpoints;

public record CreatePromptRequest
{
    public string UserEmail { get; init; } = default!;
    public string Title { get; init; } = default!;
    public string Body { get; init; } = default!;
    public string Text { get; init; } = default!;
    public string ReferenceImageUrl { get; init; } = default!;
    public string ImageResultUrl { get; init; } = default!;
    public string ReferenceText { get; init; } = default!;
    public string TextResult { get; init; } = default!;
}

internal class Create(IPromptService promptService) : Endpoint<CreatePromptRequest, Prompt>
{
    public override void Configure()
    {
        Post("/prompts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePromptRequest request, CancellationToken ct)
    {

        var newPrompt = new Prompt()
        {
            UserEmail = request.UserEmail,
            Title = request.Title,
            Body = request.Body,
            Text = request.Text,
            ReferenceImageUrl = request.ReferenceImageUrl,
            ImageResultUrl = request.ImageResultUrl,
            ReferenceText = request.ReferenceText,
            TextResult = request.TextResult
        };

        await promptService.CreatePromptAsync(newPrompt);
        await SendCreatedAtAsync<GetById>(new { newPrompt.Id }, newPrompt, cancellation: ct);
    }
}