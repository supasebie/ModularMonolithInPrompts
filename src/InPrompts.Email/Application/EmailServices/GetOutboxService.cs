using Ardalis.Result;

using MongoDB.Driver;

namespace InPrompts.Email;

internal class GetOutBoxService(IMongoCollection<EmailOutboxEntity> emailCollection) : IGetOutboxService
{
  public async Task<Result<EmailOutboxEntity>> GetUnprocessedEmail(CancellationToken ct)
  {
    var filter = Builders<EmailOutboxEntity>.Filter.Eq(entity => entity.ProcessedAt, null);
    var unsentEntity = await emailCollection.Find(filter).FirstOrDefaultAsync(cancellationToken: ct);

    if (unsentEntity is null)
    {
      return Result.NotFound();
    }

    return unsentEntity;
  }
}