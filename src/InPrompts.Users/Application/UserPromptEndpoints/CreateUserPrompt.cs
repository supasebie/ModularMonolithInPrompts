

using Ardalis.Result;

using FastEndpoints;

using MediatR;

using InPrompts.Users.UseCases;
using Ardalis.Result.AspNetCore;
using System.Security.Claims;

namespace InPrompts.Users.UserPromptsEndpoints;

public record AddUserPromptRequest
{
  public string UserEmail { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  public string Body { get; set; } = string.Empty;
  public string Text { get; set; } = string.Empty;
  public string ReferenceImageUrl { get; set; } = string.Empty;
  public string ImageResultUrl { get; set; } = string.Empty;
  public string ReferenceText { get; set; } = string.Empty;
  public string TextResult { get; set; } = string.Empty;
}

internal class AddItem(IMediator mediator) : Endpoint<AddUserPromptRequest>
{
  private const string EmailAddress = nameof(EmailAddress);

  public override void Configure()
  {
    Post("/usersprompt");
    Claims(EmailAddress);
  }

  public override async Task HandleAsync(AddUserPromptRequest req, CancellationToken ct)
  {
    var emailAddress = User.FindFirstValue(EmailAddress) ?? throw new Exception("No email address claim was found");

    req.UserEmail = emailAddress;

    var command = new AddUserPromptCommand(req);
    var result = await mediator.Send(command, ct);

    if (result.Status == ResultStatus.Unauthorized)
    {
      await SendUnauthorizedAsync(ct);
    }
    else if (result.Status == ResultStatus.Invalid)
    {
      await SendResultAsync(result.ToMinimalApiResult());
    }
    else
    {
      await SendOkAsync(ct);
    }
  }
}