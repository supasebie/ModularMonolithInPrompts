using Ardalis.Result;

using FluentValidation;

using InPrompts.Users.UserPromptsEndpoints;

using MediatR;

namespace InPrompts.Users.UseCases;

public record AddUserPromptCommand(AddUserPromptRequest UserPrompt) : IRequest<Result>;

internal class AddUserPromptHandler(IEfUserRepository userRepository
//  ISender mediator
 ) : IRequestHandler<AddUserPromptCommand, Result>
{
  public async Task<Result> Handle(AddUserPromptCommand request, CancellationToken cancellationToken)
  {
    var user = await userRepository.GetUserWithPostedPrompts(request.UserPrompt.UserEmail);

    if (user is null)
    {
      return Result.Unauthorized();
    }

    var newUserPrompt = new UserPrompt()
    {
      Title = request.UserPrompt.Title,
      Body = request.UserPrompt.Body,
      Text = request.UserPrompt.Text,
      ReferenceImageUrl = request.UserPrompt.ReferenceImageUrl,
      ImageResultUrl = request.UserPrompt.ImageResultUrl,
      ReferenceText = request.UserPrompt.ReferenceText,
      TextResult = request.UserPrompt.TextResult,
    };
    user.AddUserPrompt(newUserPrompt);
    await userRepository.SaveChangesAsync();

    return Result.Success();
  }
}

public class AddUserPromptCommandValidator : AbstractValidator<AddUserPromptCommand>
{
  public AddUserPromptCommandValidator()
  {
    RuleFor(x => x.UserPrompt.UserEmail).NotEmpty();
  }
}