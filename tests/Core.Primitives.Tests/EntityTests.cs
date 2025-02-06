namespace Bieber.Core.Primitives.Tests;

public class EntityTests
{
    #region Test Implementations
    public class TestEntity : Entity
    {
        public TestEntity(Guid id) : base(id) { }
    }
    #endregion

    [Fact]
    public void Entities_With_Same_Id_Should_Be_Equal()
    {
        var id = Guid.NewGuid();
        var entity1 = new TestEntity(id);
        var entity2 = new TestEntity(id);

        entity1.ShouldBe(entity2);
        (entity1 == entity2).ShouldBeTrue();
        (entity1 != entity2).ShouldBeFalse();
    }

    [Fact]
    public void Entities_With_Different_Id_Should_Not_Be_Equal()
    {
        var entity1 = new TestEntity(Guid.NewGuid());
        var entity2 = new TestEntity(Guid.NewGuid());

        entity1.ShouldNotBe(entity2);
        (entity1 == entity2).ShouldBeFalse();
        (entity1 != entity2).ShouldBeTrue();
    }
}
