namespace Bieber.Core.Primitives.Tests;

public class AggregateRootTests
{
    #region Test Implementations
    public class TestAggregateRoot : AggregateRoot
    {
        public TestAggregateRoot(Guid id) : base(id) { }

        public override void ApplyEvent(IDomainEvent @event)
        {
            // Apply event logic
        }
    }
    public class TestDomainEvent : IDomainEvent
    {
        public TestDomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
        public Guid AggregateId { get; }
    }
    #endregion

    [Fact]
    public void AggregateRoot_Should_Raise_Domain_Event()
    {
        var aggregate = new TestAggregateRoot(Guid.NewGuid());
        var domainEvent = new TestDomainEvent(aggregate.Id);

        aggregate.Raise(domainEvent);

        aggregate.GetDomainEvents().ShouldContain(domainEvent);
    }

    [Fact]
    public void AggregateRoot_Should_Clear_Domain_Events()
    {
        var aggregate = new TestAggregateRoot(Guid.NewGuid());
        var domainEvent = new TestDomainEvent(aggregate.Id);

        aggregate.Raise(domainEvent);
        aggregate.ClearDomainEvents();

        aggregate.GetDomainEvents().ShouldBeEmpty();
    }
}
