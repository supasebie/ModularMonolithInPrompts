using MassTransit;

using Serilog;

namespace InPrompts.EventBus;

internal class SendWelcomeEmailHandler(ILogger logger) : IConsumer<SendWelcomeEmailCommand>
{
  public async Task Consume(ConsumeContext<SendWelcomeEmailCommand> context)
  {
    logger.Information("Sending Email via Saga CorrelatebyUserId: {UserId}", context.Message.UserId);
    // await emailService.SendWelcomeEmail(context.Message.Email);

    await context.Publish(new WelcomeEmailSentEvent
    {
      UserId = context.Message.UserId,
      Email = context.Message.Email
    });

    logger.Information("Saga complete, welcome email sent CorrelatebyUserId: {UserId}", context.Message.UserId);
  }
}