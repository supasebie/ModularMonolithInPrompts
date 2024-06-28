namespace InPrompts.Email;

internal interface IMimeKitEmailSender
{
  Task SendEmailAsync(string to, string from, string subject, string body, CancellationToken ct);
}