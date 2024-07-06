using System.ComponentModel.DataAnnotations;

using MassTransit;

namespace InPrompts.EventBus;

internal class EmailNewUserSagaData : SagaStateMachineInstance
{
  [Key]
  public Guid CorrelationId { get; set; }
  public Guid UserId { get; set; }
  public string CurrentState { get; set; } = default!;
  public string Email { get; set; } = string.Empty;
  public bool WelcomeEmailSent { get; set; } = false;
  public bool NewUserSagaComplete { get; set; } = false;
}