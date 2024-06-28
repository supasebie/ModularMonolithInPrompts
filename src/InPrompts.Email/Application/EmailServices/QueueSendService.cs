using MongoDB.Driver;

namespace InPrompts.Email;

internal class QueueSendService(IMongoCollection<EmailOutboxEntity> emailCollection) : IQueueSendService
{
    public async Task QueueSendEmail(EmailOutboxEntity entity)
    {
        await emailCollection.InsertOneAsync(entity);
    }
}
