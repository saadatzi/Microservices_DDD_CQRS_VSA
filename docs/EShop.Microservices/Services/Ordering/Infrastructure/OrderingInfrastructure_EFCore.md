# Ordering.Infrastructure Layer with EF Core

The `Ordering.Infrastructure` layer leverages Entity Framework (EF) Core to manage data persistence for the ordering domain. Key tasks include mapping Domain-Driven Design (DDD) objects to EF Core entities, handling migrations, seeding, and raising domain events.

## Key Features

- **EF Core 8 Features**: Utilizing the latest features of EF Core 8, supporting the code-first approach, migrations, and SQL Server integration.
- **EF Core DBContext**: Developing a DBContext object in EF Core to handle the storage of domain entities.
- **Mapping DDD Objects to EF Entities**: Translating domain-driven design (DDD) objects like aggregates and value objects to EF Core-compatible entities.
- **Entity Configuration**: Setting up configurations for the `Order` entity using ModelBuilder and handling complex types in `Ordering.Infrastructure`.
- **Auto Migration and Seeding**: Automatically migrating and seeding EF Core entities into the SQL Server database.
- **Domain Events with MediatR**: Raising and dispatching domain events using EF Core with the MediatR library to handle communication within the domain.

## Main Target of the Infrastructure Layer

- **Domain Objects Mapping**: Mapping domain objects (Aggregates, Entities, Value Objects) to EF Core entities and migrating tables into SQL Server.
  - **Value Object Complex Types**: Supporting complex types for value objects.
  - **Aggregate Root Entities**: Ensuring that EF Core entities represent aggregate roots appropriately.

### Usage in the Ordering Domain

The infrastructure layer serves as the main interaction point between the domain and the persistence mechanism (SQL Server). By leveraging EF Core, the infrastructure layer encapsulates database logic, facilitating easier data manipulation, storage, and retrieval while maintaining domain integrity.
