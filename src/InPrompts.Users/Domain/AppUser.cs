using System.ComponentModel.DataAnnotations.Schema;

using Ardalis.GuardClauses;

using InPrompts.SharedKernel;

using Microsoft.AspNetCore.Identity;

namespace InPrompts.Users;

public class AppUser : IdentityUser<Guid>, IHaveDomainEvents
{
    private readonly List<UserPrompt> _userPrompts = [];
    private readonly List<DomainEventBase> _domainEvents = [];
    public IReadOnlyCollection<UserPrompt> UserPrompts => _userPrompts.AsReadOnly();

    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    public void AddUserPrompt(UserPrompt userPrompt)
    {
        Guard.Against.Null(userPrompt);

        var existingPrompt = UserPrompts.SingleOrDefault(p => p.Id == userPrompt.Id);

        if (existingPrompt is not null)
        {
            // Handle updates
            return;
        }

        _userPrompts.Add(userPrompt);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
}
