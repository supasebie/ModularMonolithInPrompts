using MediatR;

namespace InPrompts.SharedKernel;

public record IntegrationEventBase : INotification
{
  public DateTimeOffset OccurredAt { get; } = DateTimeOffset.UtcNow;
}