namespace InPrompts.SharedKernel;

public interface IDomainEventDispatcher
{
  Task DispatchAndClearEventsAsync(IEnumerable<IHaveDomainEvents> entitiesWithEvents);
}