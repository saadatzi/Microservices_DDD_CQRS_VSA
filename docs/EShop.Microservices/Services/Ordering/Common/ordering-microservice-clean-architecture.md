# Ordering Microservice Clean Architecture Layers

This document provides an overview of the clean architecture layers for the Ordering Microservice, covering the Domain Layer, Infrastructure Layer, Application Layer, and API Layer.

---

## Domain Layer

- **Tactical DDD (Domain-Driven Design) Implementations**: This includes entities, value objects, and aggregates.
- **Anemic-Domain Model vs. Rich-Domain Model**: Comparison between models in DDD, focusing on where business logic resides.
- **Domain Events & Integration Events**: Handling events within the domain, as well as integration with external services or systems.

---

## Infrastructure Layer

- **Entity Framework Core 8 Code First Approach**: Using EF Core for code-first migrations and SQL Server connection.
- **EF Core 8 Relations and DDD ValueObject Mapping**: Mapping complex types and properties with EF Core to model DDD ValueObjects.
- **Auto Migrate and Seed EF Core Entities**: Automatically apply migrations and seed initial data to the SQL Server database when the application starts.
- **EF Core Interceptors**: Utilize `SaveChangesInterceptor` to handle custom behaviors during database operations.

---

## Application Layer

- **CQRS with MediatR Library**: Implementing the Command and Command Handlers pattern using the MediatR library.
- **MediatR Pipeline Behaviors**: Applying additional behaviors like validation and logging to MediatR commands.
- **Domain Event Handlers with MediatR INotificationHandler**: Handling domain events through MediatR’s notification handler interface.

---

## API Layer

- **Minimal API Endpoint Definition with Carter**: Using Carter to define minimal APIs for streamlined endpoints.
- **Cross-Cutting Concerns**: Implementing a custom exception handler specifically for the Ordering Microservice to handle concerns like logging and error handling.
