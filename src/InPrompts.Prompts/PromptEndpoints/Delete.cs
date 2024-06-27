using FastEndpoints;

namespace InPrompts.Prompts.PromptEndpoints;

public record DeletePromptRequest(int Id);

internal class Delete(IPromptService promptService) : Endpoint<DeletePromptRequest, Prompt>
{
    public override void Configure()
    {
        Delete("/prompts/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeletePromptRequest request, CancellationToken ct)
    {
        var prompt = await promptService.GetPromptByIdAsync(request.Id);

        if (prompt is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await promptService.DeletePromptAsync(request.Id);
        await SendNoContentAsync(cancellation: ct);
    }
}