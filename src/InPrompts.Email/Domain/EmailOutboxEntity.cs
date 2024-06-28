using System.ComponentModel.DataAnnotations;

namespace InPrompts.Email;

public record EmailOutboxEntity(string To, string From, string Subject, string Body)
{
  [Key]
  public Guid Id { get; set; } = Guid.NewGuid();
  public DateTimeOffset? ProcessedAt { get; init; }
}