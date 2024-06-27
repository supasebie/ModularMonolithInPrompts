using FastEndpoints;

namespace InPrompts.Prompts.PromptEndpoints;

internal class Create(IPromptService promptService) : Endpoint<CreatePromptDto, PromptResponseDto>
{
    public override void Configure()
    {
        Post("/prompts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePromptDto request, CancellationToken ct)
    {

        var response = await promptService.CreatePromptAsync(request);

        await SendCreatedAtAsync<GetById>(new { response.CorrelationId }, response.Value, cancellation: ct);
    }
}