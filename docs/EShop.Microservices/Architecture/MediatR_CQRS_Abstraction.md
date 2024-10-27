# Abstraction on MediatR for CQRS

To implement the CQRS (Command Query Responsibility Segregation) pattern with MediatR in a clean and organized way, we can create abstractions that separate commands from queries. This approach uses MediatR’s `IRequest` and `IRequestHandler` interfaces and customizes them to fit CQRS principles.

---

## Interface Structure

### 1. `IRequest`
- The `IRequest` interface provided by MediatR serves as the base interface for all requests.
- We create two specialized interfaces—`IQuery` and `ICommand`—derived from `IRequest` to separate read and write operations.

### 2. `IQuery` Interface
- **Purpose**: Defines a read operation (query) that does not change application state.
- **Inheritance**: Extends `IRequest`.
- **Usage**: Any query operation should implement `IQuery` to indicate it is a read-only request.

### 3. `ICommand` Interface
- **Purpose**: Defines a write operation (command) that changes application state.
- **Inheritance**: Extends `IRequest`.
- **Usage**: Any command operation should implement `ICommand` to indicate it modifies data.

---

## Handler Structure

### 4. `IRequestHandler`
- MediatR’s `IRequestHandler` interface serves as the base handler for processing requests.
- We create two specialized handler interfaces—`IQueryHandler` and `ICommandHandler`—to separate handling logic for queries and commands.

### 5. `IQueryHandler` Interface
- **Purpose**: Handles queries that implement the `IQuery` interface.
- **Inheritance**: Extends `IRequestHandler`.
- **Usage**: Handlers for read operations should implement `IQueryHandler`, focusing on retrieving data without changing the application state.

### 6. `ICommandHandler` Interface
- **Purpose**: Handles commands that implement the `ICommand` interface.
- **Inheritance**: Extends `IRequestHandler`.
- **Usage**: Handlers for write operations should implement `ICommandHandler`, focusing on modifying the application state.

---

## Summary

This abstraction structure ensures a clear separation between queries and commands within a CQRS-based application using MediatR. By distinguishing read and write requests and their respective handlers, the codebase becomes more maintainable, modular, and easier to understand.

Using these interfaces, developers can enforce a consistent pattern for managing CQRS operations, making the code more organized and following the CQRS design principles effectively.
