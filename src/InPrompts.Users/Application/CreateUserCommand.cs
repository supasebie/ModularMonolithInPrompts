using Ardalis.Result;

using InPrompts.EventBus;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Identity;

namespace InPrompts.Users;

internal record CreateUserCommand(string Email, string Password) : IRequest<Result>;

internal class CreateUserCommandHandler(UserManager<AppUser> userManager, IMessagePublisher messagePublisher) : IRequestHandler<CreateUserCommand, Result>
{
  public async Task<Result> Handle(CreateUserCommand command, CancellationToken ct)
  {
    var user = await userManager.FindByEmailAsync(command.Email);

    if (user != null) return Result.Error("This email is already in use");

    var newUser = new AppUser { Email = command.Email, UserName = command.Email };

    var result = await userManager.CreateAsync(newUser, command.Password);

    // send welcome email
    // var emailCommand = new SendEmailCommand(command.Email,
    //     "donotreply@test.com",
    //     "Welcome to InPrompts!",
    //     "Thank you for registering!");

    // _ = await mediator.Send(emailCommand, ct);
    await messagePublisher.PublishNewUser(newUser.Id, newUser.Email);

    if (!result.Succeeded)
    {
      return Result.Error(new ErrorList(result.Errors.Select(error => error.Description)));
    }
    return Result.Success();
  }
}