namespace Bieber.Core.Primitives;
/// <summary>
/// Represents a domain event in the domain-driven design context.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Gets the unique identifier of the aggregate associated with the domain event.
    /// </summary>
    public Guid AggregateId { get; }
}
