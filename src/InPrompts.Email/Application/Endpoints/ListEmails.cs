using FastEndpoints;

using MongoDB.Driver;

namespace InPrompts.Email;

public record ListEmailsResponse(int Count, List<EmailOutboxEntity> Emails);

internal class ListEmails(IMongoCollection<EmailOutboxEntity> emailCollection) : EndpointWithoutRequest<ListEmailsResponse>
{
  public override void Configure()
  {
    Get("/emails");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var filter = Builders<EmailOutboxEntity>.Filter.Empty;
    var emailEntities = await emailCollection.Find(filter).ToListAsync();

    var response = new ListEmailsResponse(emailEntities.Count, emailEntities);

    Response = response;
  }
}