using Ardalis.Result;

namespace InPrompts.Email;

internal interface IGetOutboxService
{
  Task<Result<EmailOutboxEntity>> GetUnprocessedEmail(CancellationToken ct);
}