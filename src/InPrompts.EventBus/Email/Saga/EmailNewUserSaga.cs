using MassTransit;

namespace InPrompts.EventBus;

internal class EmailNewUserSaga : MassTransitStateMachine<EmailNewUserSagaData>
{
  public State Welcoming { get; set; } = default!;

  public Event<UserRegisteredEvent> UserRegisteredEvent { get; set; } = default!;
  public Event<WelcomeEmailSentEvent> WelcomeEmailSentEvent { get; set; } = default!;

  public EmailNewUserSaga()
  {
    InstanceState(s => s.CurrentState);

    Event(() => UserRegisteredEvent, e => e.CorrelateById(m => m.Message.UserId));
    Event(() => WelcomeEmailSentEvent, e => e.CorrelateById(m => m.Message.UserId));

    Initially(
      When(UserRegisteredEvent)
      .Then(context =>
      {
        context.Saga.UserId = context.Message.UserId;
        context.Saga.Email = context.Message.Email;
      })
      .TransitionTo(Welcoming)
      .Publish(context => new SendWelcomeEmailCommand(context.Message.UserId, context.Message.Email)));

    During(Welcoming,
      When(WelcomeEmailSentEvent)
      .Then(context => context.Saga.WelcomeEmailSent = true)
      .Finalize());
  }
}