namespace InPrompts.Email;

internal interface ISendOutboxService
{
  Task SendOutBoxEmails(CancellationToken ct);
}