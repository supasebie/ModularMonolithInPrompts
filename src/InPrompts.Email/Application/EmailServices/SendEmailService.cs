
using Ardalis.Result;

using MongoDB.Driver;

namespace InPrompts.Email;

internal class SendEmailService(IGetOutboxService outboxService, IMimeKitEmailSender emailSender, IMongoCollection<EmailOutboxEntity> emailCollection) : ISendOutboxService
{
  public async Task SendOutBoxEmails(CancellationToken ct = default)
  {
    var result = await outboxService.GetUnprocessedEmail(ct);

    if (result.Status == ResultStatus.NotFound)
    {
      return;
    }

    var emailEntity = result.Value;
    await emailSender.SendEmailAsync(emailEntity.To, emailEntity.From, emailEntity.Subject, emailEntity.Body, ct);

    var updateFilter = Builders<EmailOutboxEntity>.Filter.Eq(x => x.Id, emailEntity.Id);

    var update = Builders<EmailOutboxEntity>.Update.Set(nameof(EmailOutboxEntity.ProcessedAt), DateTimeOffset.UtcNow);
    await emailCollection.UpdateOneAsync(updateFilter, update, cancellationToken: ct);
  }
}
