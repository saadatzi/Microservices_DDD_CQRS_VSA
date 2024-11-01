# EF Core Interceptors: SaveChangesInterceptor for Auditing Entities

## Overview

- **Interceptors** in Entity Framework (EF) Core enable the interception, modification, or suppression of **EF Core operations**.
- This includes both **low-level database operations** (such as executing a command) and **higher-level operations** (such as calls to `SaveChanges`).

## SaveChanges Interception

### Purpose
- The **SaveChanges** and **SaveChangesAsync** interception points are used to execute **custom logic** when saving changes to the database.
  
### Implementation
- These interception points are defined by the `ISaveChangesInterceptor` interface.

### EF Core's SaveChangesInterceptor Class
- EF Core provides a `SaveChangesInterceptor` base class with **no-op (no operation) methods** as a convenience for users implementing custom logic.

## Use Cases for SaveChangesInterceptor
- **Auditing**: Track changes to entities, such as when records were created or modified.
- **Validation**: Apply additional validations before committing changes.
- **Event Logging**: Record actions that modify the database.
- **Security**: Control and log sensitive changes to ensure compliance.

### Example Code Usage
To use `SaveChangesInterceptor`, create a class that inherits from `SaveChangesInterceptor` and override the desired methods to inject your custom logic.

```csharp
using Microsoft.EntityFrameworkCore.Diagnostics;

public class AuditInterceptor : SaveChangesInterceptor
{
    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        // Custom auditing logic here
        Console.WriteLine("Changes saved to the database.");
        return base.SavedChanges(eventData, result);
    }
}
```

With this setup, you can inject `AuditInterceptor` into your DbContext options to apply it globally.

## Use Case: SaveChanges Interception for Auditing

- Interception of **SaveChanges** can be used to create an independent **audit record** of changes.
- This is useful for **maintaining a history** of who changed an entity and when.
- Before saving changes to the database, you can **iterate** through the changed entities in the **DbContext** and **log or store** the audit information, such as timestamps or user identifiers.

## Registering Interceptors

### How to Register Interceptors?
- Interceptors are registered using **AddInterceptors** when configuring a **DbContext** instance.
- The common approach is to add interceptors in the **OnConfiguring** method of the DbContext.

### Example Code: Registering a SaveChangesInterceptor
```csharp
public class ExampleContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.AddInterceptors(new SaveChangesInterceptor());
}
```

This code demonstrates how to register a `SaveChangesInterceptor` to a DbContext, allowing it to intercept and handle all `SaveChanges` calls with custom logic.

## Implementing a Custom SaveChangesInterceptor

### Overview
- Implement a custom interceptor by extending `SaveChangesInterceptor` or implementing `ISaveChangesInterceptor`.
- Override methods like **SavingChanges** and **SavedChanges** to execute custom logic.

### Example Code: Implementing Auditing in an Interceptor
```csharp
public class MySaveChangesInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;
        foreach (var entry in context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            // Example: Set audit fields based on entity state
            if (entry.Entity is AuditableEntity entity)
            {
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                    entity.CreatedBy = // get current user
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.UpdatedAt = DateTime.UtcNow;
                    entity.UpdatedBy = // get current user
                }
            }
        }

        return base.SavingChanges(eventData, result);
    }
}
```

In this example, `MySaveChangesInterceptor` overrides `SavingChanges` to automatically set auditing fields (`CreatedAt`, `CreatedBy`, `UpdatedAt`, and `UpdatedBy`) based on the state of the entity. This is useful for creating an audit trail of changes in the database.

## Conclusion
The **SaveChangesInterceptor** in EF Core is a powerful tool for developers needing custom control over database save operations. It simplifies the implementation of auditing, logging, and security tasks by centralizing the custom logic at the interception points.