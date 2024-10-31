# Patterns & Principles of Ordering Microservices

This document outlines the key patterns and principles used in the Ordering Microservices architecture, focusing on both common foundational principles and domain layer patterns.

---

## Common Principles

1. **SOLID**: A set of five principles to design software that is more understandable, flexible, and maintainable.
   - **S**ingle Responsibility Principle
   - **O**pen/Closed Principle
   - **L**iskov Substitution Principle
   - **I**nterface Segregation Principle
   - **D**ependency Inversion Principle

2. **KISS (Keep It Simple, Stupid)**: Encourages simplicity in design to enhance readability and maintainability.

3. **YAGNI (You Aren’t Gonna Need It)**: Avoids adding functionality until it is absolutely necessary.

4. **SoC (Separation of Concerns)**: Divides a program into distinct sections, each addressing a specific concern or functionality.

5. **DIP (Dependency Injection Principle)**: Encourages dependency injection to reduce tight coupling between components, enhancing flexibility.

6. **Dependency Injection**: Enables inversion of control by injecting dependencies, improving modularity and testability.

---

## Domain Layer Patterns

1. **DDD-Oriented Microservice Design**: Utilizes Domain-Driven Design (DDD) Tactical Patterns to structure the microservice around business concepts and domain logic.

2. **Domain Entity Pattern**: Defines the core entities in the domain model, using base classes and a common SeedWork library to enforce consistency.

3. **Anemic-Domain Model vs Rich-Domain Model**:
   - **Anemic-Domain Model**: Entities with little or no business logic, relying on services for behavior.
   - **Rich-Domain Model**: Entities encapsulate their own behavior, aligning closely with DDD principles.

4. **Value Object Pattern**: Represents immutable objects that don’t have distinct identities, used to encapsulate domain concepts that don’t require separate instances.

5. **Aggregate Pattern**: Groups related entities together to be treated as a single unit.
   - **Aggregate Root**: The main entity that governs the integrity of the aggregate.

6. **Strongly Typed IDs Pattern**: Utilizes custom types for IDs to prevent accidental misuses of identifiers between different entities.

7. **Domain Events vs Integration Events**:
   - **Domain Events**: Triggered by changes within the domain, notifying other parts of the system of important business occurrences.
   - **Integration Events**: Used to communicate between microservices, typically facilitated by message brokers to ensure reliable delivery across services.

---

## Infrastructure Data Layer Patterns

1. **Repository Pattern**: Manages the persistence of domain objects and provides a collection-like interface for accessing them.

2. **EF Core ORM**: Utilizes Entity Framework Core with a Code-First Approach, handling migrations and seeding of the database.

3. **Value Object Complex Types**: Supports complex types as Value Objects in Entity Framework, enforcing DDD principles and ensuring immutability.

4. **Entity Configurations with ModelBuilder**: Uses Entity Framework’s `ModelBuilder` to define configurations for entities, aligning DDD concepts with EF Core entities.

5. **Raise & Dispatch Domain Events with EF Core and MediatR**: Leverages EF Core’s domain event capabilities along with MediatR to raise and dispatch events within the domain model.

---

## Application UC Layer Patterns

1. **CQRS and CQS Pattern**: Separates commands (state changes) and queries (data retrieval) to improve system scalability and maintainability.

2. **Command and Command Handler Patterns**: Implements commands and handlers to encapsulate business actions, promoting a clean separation of concerns.

3. **Mediator Pattern with MediatR**: Uses the MediatR library to handle requests within the application layer, allowing loose coupling between request senders and handlers.

4. **Pipeline Behaviors (Validation, Logging)**: Integrates cross-cutting concerns like validation and logging in the pipeline using MediatR behaviors.

5. **Fluent Validation and Cross-cutting Concerns**: Utilizes FluentValidation for input validation and ensures that cross-cutting concerns (like logging) are handled consistently.

## Presentation API Layer Patterns

This layer focuses on defining the API endpoints and the external-facing parts of the microservice. It uses the latest ASP.NET Core features to handle requests and provide responses effectively.

### Key Patterns

- **Minimal APIs**: Simplifies the API setup by minimizing the boilerplate code, allowing for more concise route and handler definitions.
- **ASP.NET DI and Routing**: Leverages ASP.NET Core's Dependency Injection (DI) and routing features, utilizing the latest enhancements in ASP.NET 8.

### Section Flow

To maintain a clear architectural flow, the layers are organized as follows:
1. **Domain**
2. **Infrastructure**
3. **Application**
4. **Presentation**

> **Note**: Domain entities are mapped to EF.Core objects right after the Domain Layer is developed. This ensures a clean mapping between domain models and database entities, facilitating better consistency and alignment with DDD principles.
