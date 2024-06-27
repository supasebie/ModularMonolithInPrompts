using FastEndpoints;

namespace InPrompts.Prompts.PromptEndpoints;

public record GetPromptByIdRequest(int Id);

internal class GetById(IPromptService promptService) : Endpoint<GetPromptByIdRequest, Prompt>
{
    public override void Configure()
    {
        Get("/prompt/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetPromptByIdRequest request, CancellationToken ct)
    {
        var prompt = await promptService.GetPromptByIdAsync(request.Id);

        if (prompt is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendAsync(prompt, cancellation: ct);
    }
}