
using Ardalis.Result;

using InPrompts.Email.Contracts;

using MediatR;

namespace InPrompts.Email;

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
