
using Ardalis.Result;

using MediatR;

namespace InPrompts.Email;

public record SendEmailCommand(string To, string From, string Subject, string Body) : IRequest<Result<Guid>>;

internal class QueueSendCommandHandler(IQueueSendService queueSendService) : IRequestHandler<SendEmailCommand, Result<Guid>>
{
  public async Task<Result<Guid>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
  {
    var newEntity = new EmailOutboxEntity(
      request.To,
      request.From,
      request.Subject,
      request.Body
    );

    await queueSendService.QueueSendEmail(newEntity);

    return newEntity.Id;
  }
}
