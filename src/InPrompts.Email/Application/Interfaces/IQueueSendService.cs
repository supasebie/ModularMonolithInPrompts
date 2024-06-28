namespace InPrompts.Email;

internal interface IQueueSendService
{
  Task QueueSendEmail(EmailOutboxEntity entity);
}