
using System.Runtime.CompilerServices;

using MassTransit;

namespace InPrompts.EventBus;

public class MessagePublisher(IPublishEndpoint publishEndpoint) : IMessagePublisher
{
  public async Task PublishNewUser(Guid UserId, string Email)
  {
    await publishEndpoint.Publish(new UserRegisteredEvent
    {
      Email = Email,
      UserId = UserId
    });
  }
}