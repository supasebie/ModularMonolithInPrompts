
using MassTransit;

using Serilog;

namespace InPrompts.EventBus;

internal class NewUserRegisteredHandler(ILogger logger) : IConsumer<NewUserRegisteredCommand>
{
  public async Task Consume(ConsumeContext<NewUserRegisteredCommand> context)
  {

    logger.Information("NewUserRegistered Saga Initiated CorrelatebyUserId: {UserId}", context.Message.UserId);

    await context.Publish(new UserRegisteredEvent
    {
      UserId = context.Message.UserId,
      Email = context.Message.Email
    });
  }
}