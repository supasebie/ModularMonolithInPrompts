using InPrompts.SharedKernel;

namespace InPrompts.EventBus;

public record UserRegisteredEvent : IntegrationEvent
{
  public Guid UserId { get; init; }
  public string Email { get; init; } = string.Empty;
}

public record WelcomeEmailSentEvent : IntegrationEvent
{
  public Guid UserId { get; init; }
  public string Email { get; init; } = string.Empty;
}