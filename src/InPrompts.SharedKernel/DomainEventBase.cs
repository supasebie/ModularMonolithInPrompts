using MediatR;

namespace InPrompts.SharedKernel;

public record DomainEventBase : INotification
{
  public DateTimeOffset OccurredAt { get; } = DateTimeOffset.UtcNow;
}