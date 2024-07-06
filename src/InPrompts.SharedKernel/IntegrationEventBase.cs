using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using MediatR;

namespace InPrompts.SharedKernel;

public record IntegrationEventBase : INotification
{
  public Guid CorrelationId { get; set; } = Guid.NewGuid();
  public DateTimeOffset OccurredAt { get; } = DateTimeOffset.UtcNow;
}

public record IntegrationEvent
{
  public IntegrationEvent()
  {
    CorrelationId = Guid.NewGuid();
    CreationDate = DateTime.UtcNow;
  }

  [JsonConstructor]
  public IntegrationEvent(Guid correlationId, DateTime createDate)
  {
    CorrelationId = correlationId;
    CreationDate = createDate;
  }

  [Key]
  [JsonInclude]
  public Guid CorrelationId { get; private init; }

  [JsonInclude]
  public DateTime CreationDate { get; private init; }
}