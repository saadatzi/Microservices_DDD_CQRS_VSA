# Entity Framework Core

Entity Framework (EF) Core is a modern, lightweight, extensible, and cross-platform data access technology for .NET applications. It simplifies data access by allowing .NET developers to work with databases using .NET objects, eliminating much of the data access code that typically needs to be written.

## Key Features of EF Core

- **Lightweight and Extensible**: EF Core is designed to be a lightweight, open-source, and extensible framework suitable for cross-platform applications.
- **Object-Relational Mapper (O/RM)**: EF Core serves as an object-relational mapper, allowing developers to work with databases in an object-oriented way.
- **Supports .NET Objects**: Enables .NET developers to interact with databases using familiar .NET objects.
- **Reduces Data-Access Code**: EF Core eliminates the need for most of the repetitive data-access code, making development faster and less error-prone.
- **Database Engine Support**: EF Core supports multiple database engines, providing flexibility for applications that may use various databases.

### Benefits of Using EF Core

1. **Productivity**: Simplifies database access code, allowing developers to focus on the business logic.
2. **Flexibility**: Supports a wide range of database engines, making it adaptable to various systems.
3. **Cross-Platform Compatibility**: Works across different platforms, supporting Windows, Linux, and macOS development environments.


# Entity Framework Core NuGet Packages for DB Providers

Entity Framework (EF) Core supports multiple database systems through the use of **database providers**. Each database system requires its own specific provider, which is available as a NuGet package.

## Supported Database Providers

| Database System               | NuGet Package                                           |
|-------------------------------|---------------------------------------------------------|
| SQL Server and SQL Azure      | [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer) |
| SQLite                        | [Microsoft.EntityFrameworkCore.Sqlite](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite) |
| Azure Cosmos DB               | [Microsoft.EntityFrameworkCore.Cosmos](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Cosmos) |
| PostgreSQL                    | [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL) |
| MySQL                         | [Pomelo.EntityFrameworkCore.MySql](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql) |
| EF Core in-memory database    | [Microsoft.EntityFrameworkCore.InMemory](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory) |

### Key Points

- **EF Core** provides support for **different database systems** by utilizing dedicated **database providers**.
- Each **database provider** is distributed as a **NuGet package**, making it easy to add support for a specific database within an application.
- Some providers, like those for **SQL Server**, **PostgreSQL**, and **MySQL**, are developed and maintained by third parties but are fully compatible with EF Core.
