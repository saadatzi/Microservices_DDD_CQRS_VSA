# REST API Endpoints of Discount Microservices

This document outlines the gRPC methods used in the Discount Microservices, along with their corresponding request URIs and use cases.

| Method (gRPC)      | Request URI              | Use Cases                        |
|--------------------|--------------------------|----------------------------------|
| **GetDiscount**    | `GetDiscountRequest`     | Retrieve discount by product name |
| **CreateDiscount** | `CreateDiscountRequest`  | Create a new discount entry      |
| **UpdateDiscount** | `UpdateDiscountRequest`  | Update an existing discount      |
| **DeleteDiscount** | `DeleteDiscountRequest`  | Delete a discount                |

Each method in this microservice corresponds to a specific discount-related operation. These endpoints help manage discount data, making it possible to create, retrieve, update, or delete discount information.




# .NET CLI and Visual Studio Code
=====================================

### 1. Install dotnet-ef Tool

Install the Entity Framework Core CLI tool globally, which is required for creating migrations and updating the database from the command line:

```bash
dotnet tool install --global dotnet-ef
```

### 2. Add EF Core Design Package

Install the EF Core design package, which includes tools for creating migrations:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### 3. Add a Migration

Create a migration using the dotnet ef CLI command, specifying a name such as `InitialCreate` for the initial schema migration:

```bash
dotnet ef migrations add InitialCreate
```

### 4. Update the Database

Apply migrations to the database, aligning the database schema with the current EF Core model:

```bash
dotnet ef database update
```