namespace Bieber.Core.Primitives;

/// <summary>
/// Represents the base class for aggregate roots in the domain-driven design context.
/// An aggregate root is an entity that serves as the entry point for an aggregate.
/// </summary>
public abstract class AggregateRoot(Guid id) : Entity(id)
{
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>
    /// Gets the domain events that have been raised.
    /// </summary>
    /// <returns>A read-only collection of domain events.</returns>
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();

    /// <summary>
    /// Raises a domain event and adds it to the list of domain events.
    /// </summary>
    /// <param name="domainEvent">The domain event to raise.</param>
    public void Raise(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    /// <summary>
    /// Clears all the domain events that have been raised.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();

    /// <summary>
    /// Applies a collection of domain events to the aggregate root.
    /// </summary>
    /// <param name="events">The collection of domain events to apply.</param>
    public void ApplyEvents(IEnumerable<IDomainEvent> events)
    {
        foreach (IDomainEvent @event in events)
        {
            ApplyEvent(@event);
        }
    }

    /// <summary>
    /// Applies a single domain event to the aggregate root.
    /// </summary>
    /// <param name="event">The domain event to apply.</param>
    public abstract void ApplyEvent(IDomainEvent @event);
}
