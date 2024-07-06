namespace InPrompts.EventBus;

public interface IMessagePublisher
{
  Task PublishNewUser(Guid userId, string Email);
}