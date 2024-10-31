Here's a comprehensive Markdown document that covers the content of the provided images:

```markdown
# Domain-Driven Design (DDD) Concepts in Clean Architecture

## DDD Types: Strategic and Tactical DDD

### Strategic DDD
- Focuses on understanding and modeling the business domain.
- Involves identifying different domains, their subdomains, and how they interact with each other.

### Tactical DDD
- Deals with implementation details and provides design patterns.
- Includes patterns like Entities, Value Objects, Aggregates, and Aggregate Roots.

> **Note**: This document focuses on Strategic DDD and its key concepts.

---

## Tactical Domain-Driven Design

- **Tactical DDD**: A set of patterns and principles to help model complex software systems.
- **Focus**: Domain and domain logic, emphasizing the importance of a model that reflects the business and its rules.
- **Key Patterns**:
  - **Entities**
  - **Value Objects**
  - **Aggregates**
  - **Aggregate Roots**

---

## Entities

- **Entity**: An object identified by its identity (ID) rather than its attributes.
  - **Uniqueness**: Each entity is unique, even if other attributes are the same.
  - **Usage**: Represents objects in the system with a distinct identity and lifecycle.
  - **Example**: In an ordering microservice, an Order can be an Entity, uniquely identified by `OrderId`.

```csharp
public class Order : Entity
{
    public OrderId Id { get; private set; }
    // Other properties and methods
}
```

---

## Value Objects

- **Value Object**: An object describing a characteristic or attribute without a concept of identity.
  - **Immutability**: Value Objects are immutable and often encapsulate complex attributes.
  - **Usage**: Describe domain aspects with no conceptual identity.
  - **Example**: `Address` in an Order, essential for the order but not defining its identity.

```csharp
public class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    // Other properties and constructor
}
```

---

## Aggregates

- **Aggregate**: A cluster of domain objects (Entities and Value Objects) treated as a single unit.
  - **Aggregate Root**: One component of an Aggregate that acts as the root.
  - **Boundary**: Defines a boundary around related objects, maintaining consistency within this boundary.
  - **Example**: `Order` can be an Aggregate, containing OrderItems, PaymentDetails, etc., ensuring consistency.

```csharp
public class Order : Aggregate<OrderId>
{
    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
    // Other properties and methods
}
```

---

## Aggregate Roots

- **Aggregate Root**: The main Entity in an Aggregate, through which external objects interact with the Aggregate.
  - **Gateway**: Acts as a gateway to ensure the Aggregate's invariants are enforced.
  - **Example**: In the `Order Aggregate`, Order acts as the Aggregate Root.

```csharp
public class Order : Entity // Aggregate Root
{
    private List<OrderItem> _orderItems;
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
    // Other properties and methods
}
```