# Bieber.Core.Primitives

`Bieber.Core.Primitives` is a foundational library for domain-driven design (DDD) contexts. It includes abstract base classes and interfaces for entities and aggregate roots, providing a solid foundation for building robust domain models.

## Features

- **Entity**: Represents an abstract base class for entities with a unique identifier, providing equality comparison based on the entity's identifier.
- **AggregateRoot**: Represents the base class for aggregate roots in the domain-driven design context, handling domain events.
- **IDomainEvent**: Represents a domain event interface with a unique identifier for the associated aggregate.

## Installation

Add the `Bieber.Core.Primitives` library to your project using the .NET CLI:

```sh
dotnet add package Bieber.Core.Primitives
```
Or add the package reference directly in your .csproj file:
```xml
<PackageReference Include="Bieber.Core.Primitives" Version="1.0.0" />
```

## Usage

### Entity

The `Entity` class provides a base for all entities with a unique identifier and includes methods for equality comparison.

```c#
using Bieber.Core.Primitives;

public class Customer : Entity
{
    public Customer(Guid id) : base(id) { }

    // Additional properties and methods
}

var customer1 = new Customer(Guid.NewGuid());
var customer2 = new Customer(Guid.NewGuid());
```

### AggregateRoot

The `AggregateRoot` class extends Entity and includes functionality for raising and handling domain events.

```c#
using Bieber.Core.Primitives;
using System.Collections.Generic;

public class Order : AggregateRoot
{
    public Order(Guid id) : base(id) { }

    public override void ApplyEvent(IDomainEvent @event)
    {
        // Apply event logic
    }
}

public class OrderCreatedEvent : IDomainEvent
{
    public Guid AggregateId { get; }

    public OrderCreatedEvent(Guid aggregateId)
    {
        AggregateId = aggregateId;
    }
}

var order = new Order(Guid.NewGuid());
var orderCreatedEvent = new OrderCreatedEvent(order.Id);

order.Raise(orderCreatedEvent);
var events = order.GetDomainEvents(); // Contains orderCreatedEvent

```

## License

This project is licensed under the MIT License. For more information, please see the LICENSE file.

## Contributions

We welcome contributions to improve this library. Please fork the repository and submit pull requests with your changes.
