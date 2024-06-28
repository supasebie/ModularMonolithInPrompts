using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InPrompts.Email;

internal class EmailBackgroundService(ISendOutboxService sendOutboxService, ILogger<EmailBackgroundService> logger) : BackgroundService
{
  private const int DelayMS = 3_000;

  protected override async Task ExecuteAsync(CancellationToken ct)
  {
    logger.LogInformation("{serviceName} starting...", nameof(EmailBackgroundService));

    while (!ct.IsCancellationRequested)
    {
      try
      {
        await sendOutboxService.SendOutBoxEmails(ct);
      }
      catch (Exception ex)
      {
        logger.LogInformation(ex.ToString());
        logger.LogError("Error at EmailBackgroundService: {error}", ex.Message);
      }
      finally
      {
        await Task.Delay(DelayMS, ct);
      }
    }
    logger.LogInformation("{serviceName} finished...", nameof(EmailBackgroundService));
  }
}