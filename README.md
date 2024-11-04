# Architectures, Patterns, Libraries, and Best Practices

```
Architectures, Patterns, Libraries, and Best Practices
├── Architectures
│   ├── Layered Architecture
│   ├── Vertical Slice Architecture
│   ├── Domain-Driven Design (DDD)
│   └── Clean Architecture
├── Patterns & Principles
│   ├── SOLID
│   ├── Dependency Injection (DI)
│   ├── CQRS (Command Query Responsibility Segregation)
│   ├── Mediator Pattern
│   ├── Proxy Pattern
│   ├── Decorator Pattern
│   ├── Options Pattern
│   ├── Pub/Sub (Publish/Subscribe)
│   ├── Caching
│   └── API Gateway
├── Databases
│   ├── Transactional Document DB
│   ├── PostgreSQL
│   ├── Redis
│   ├── SQLite
│   └── SQL Server
├── Libraries
│   ├── Carter
│   ├── Marten
│   ├── MediatR
│   ├── Mapster
│   ├── MassTransit
│   ├── FluentValidation
│   ├── Entity Framework (EF) Core
│   └── Refit
├── Containerization and Orchestration
│   ├── Dockerfiles
│   └── Docker Compose
├── API Gateway and Client
│   ├── YARP API Gateway
│   └── Shopping Web
└── Communications
    ├── gRPC (Sync)
    └── Publish/Subscribe with MassTransit and RabbitMQ (Async)
```

## Architectures
- **Layered Architecture**  
  Structured with distinct layers that separate concerns, e.g., presentation, business, and data access layers.
- **Vertical Slice Architecture**  
  Organizes code by feature rather than technical layers, focusing on individual, vertical "slices" of functionality.
- **Domain-Driven Design (DDD)**  
  An approach to software design focusing on modeling real-world business domains and understanding domain-specific logic.
- **Clean Architecture**  
  Emphasizes separation of concerns, with independent layers, allowing the core logic to remain unaffected by external changes.

## Patterns & Principles
- **SOLID, Dependency Injection (DI)**  
  Core principles of object-oriented design and dependency management to build robust, scalable applications.
- **CQRS (Command Query Responsibility Segregation)**  
  Separates read and write operations into different models, optimizing each independently.
- **Mediator, Proxy, Decorator, Options**  
  - **Mediator**: Simplifies communication between objects by centralizing it.
  - **Proxy**: Controls access to an object, enhancing or limiting functionality.
  - **Decorator**: Dynamically adds behavior to an object without modifying its structure.
  - **Options**: Encapsulates configurations, typically using strongly-typed objects for better management.
- **Pub/Sub, Caching**  
  - **Pub/Sub (Publish/Subscribe)**: Asynchronous messaging for event-driven systems.
  - **Caching**: Stores frequently accessed data to improve performance.
- **API Gateway**  
  A single entry point to manage and route client requests, handling cross-cutting concerns like security, logging, and load balancing.

## Databases
- **Transactional Document DB**  
  Supports ACID transactions for document-based data stores, ideal for applications needing transactional integrity.
- **PostgreSQL**  
  A powerful, open-source object-relational database system.
- **Redis**  
  An in-memory key-value store, widely used for caching and real-time analytics.
- **SQLite**  
  A lightweight, file-based database for local data storage.
- **SQL Server**  
  Microsoft’s relational database management system.

## Libraries
- **Carter**  
  Minimalist library for building APIs with ASP.NET Core.
- **Marten**  
  Document database and event store library for .NET using PostgreSQL.
- **MediatR**  
  Simplifies and centralizes command and query processing, commonly used with CQRS.
- **Mapster**  
  Object-to-object mapping library to simplify data transformations.
- **MassTransit**  
  Distributed application framework for messaging with support for RabbitMQ and other message brokers.
- **FluentValidation**  
  A popular .NET library for building strongly-typed validation rules.
- **Entity Framework (EF) Core, Refit**  
  - **EF Core**: Object-relational mapper (ORM) for .NET to simplify database interactions.
  - **Refit**: Automatically generates REST API clients for .NET applications based on interfaces.

## Containerization and Orchestration
- **Dockerfiles and Docker Compose**  
  - **Dockerfiles**: Defines the build steps and environment for a Docker container.
  - **Docker Compose**: Defines and manages multi-container Docker applications, enabling container orchestration.

## API Gateway and Client
- **YARP API Gateway**  
  A reverse proxy solution for routing and load balancing in .NET applications, ideal for Gateway Routing.
- **Shopping Web**  
  Utilizes the Refit library to consume APIs, simplifying HTTP calls in client applications.

## Communications
- **Sync: gRPC**  
  - High-performance, open-source RPC framework for synchronous communication, ideal for real-time applications.
- **Async: Publish/Subscribe Pattern with MassTransit and RabbitMQ**  
  - Uses MassTransit with RabbitMQ for asynchronous messaging, allowing loose coupling and scalability in distributed systems.

### Running the Solution
1. **Build the Docker Image**:
   ```bash
   docker build -f Dockerfile_Ordering -t eshop/ordering .
   docker build -f Dockerfile_Basket -t eshop/basket .
   docker build -f Dockerfile_Discount -t eshop/discount .
   docker build -f Dockerfile_Catalog -t eshop/catalog .
    ```

2. **Spin up the Solution**
   ```bash
   docker-compose up -d
    ```