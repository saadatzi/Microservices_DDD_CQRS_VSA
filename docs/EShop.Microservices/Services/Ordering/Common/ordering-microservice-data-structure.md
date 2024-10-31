# Underlying Data Structures of Ordering Microservices

This document describes the underlying data structures used within the Ordering Microservices, with a focus on the database and ORM framework.

---

## Datastore Overview

The Ordering Microservices have a single datastore:

### 1. SQL Server Relational Database

- **Purpose**: Used for storing `Orders` and `OrderItems` in a structured and relational format.
  
- **Database Technology**: SQL Server, a reliable and widely-used relational database system.

- **ORM Tool**: Entity Framework Core (EF Core) is chosen as the Object-Relational Mapper (ORM), enabling the use of the Code-First approach.
  
- **Domain Modeling**: The domain models are mapped to EF Core entities. Domain-Driven Design (DDD) concepts such as Aggregates and Value Objects are utilized in the data structure, ensuring a clean and maintainable codebase.

---

## Key Benefits of This Structure

- **Code-First Approach**: This approach allows developers to define models in code, which EF Core then uses to create and maintain the database schema.
  
- **DDD Support**: Aggregates and Value Objects help maintain consistency and encapsulate the business rules within the domain.

- **Entity Framework Core**: Provides an abstraction over SQL Server, simplifying CRUD operations and database migrations.
