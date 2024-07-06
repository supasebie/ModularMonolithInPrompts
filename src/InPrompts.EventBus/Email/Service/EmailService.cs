
// using InPrompts.Email.Contracts;

// using MediatR;

// namespace InPrompts.EventBus;

// internal class EmailService(Mediator mediator, CancellationToken ct) : IEmailService
// {
//   public async Task SendWelcomeEmail(string Email)
//   {

//     // send welcome email
//     var emailCommand = new SendEmailCommand(Email,
//         "donotreply@test.com",
//         "Welcome to InPrompts!",
//         "Thank you for registering!");

//     _ = await mediator.Send(emailCommand, ct);
//   }
// }
