# Understanding Proxy and Decorator Patterns with Scrutor Library in .NET

## Proxy Pattern

The Proxy Pattern provides a placeholder for another object to control access to it. This pattern creates a proxy object that acts as an intermediary for requests directed towards the original object. It can be used for:

- **Lazy loading**: Loading objects only when necessary.
- **Controlling access**: Restricting access to sensitive objects.
- **Logging**: Keeping track of requests for auditing purposes.

The Proxy Pattern functions as a gatekeeper, adding extra behavior or checks before accessing the actual object.

### Key Benefits
- Allows controlled access to an object.
- Provides a mechanism for lazy loading and logging.

## Decorator Pattern

The Decorator Pattern dynamically adds behavior to an object without altering its structure. It involves a set of decorator classes that extend the functionality of the original class without modifying its core code. This pattern is particularly useful for adding functionalities to objects at runtime.

- **Example**: Enhancing a window object with additional features, such as borders and scrollbars, dynamically.

### Key Benefits
- Extends functionality of classes at runtime.
- Maintains the original object's structure and integrity.

## Implementing the Decorator Pattern Using Scrutor Library

### What is Scrutor Library?

Scrutor is a .NET library that extends the built-in IOC (Inversion of Control) container of ASP.NET Core. It provides additional capabilities to scan and register services in a flexible manner.

### Usage of Scrutor
- Useful for implementing patterns like **Decorator** in a clean and manageable way.
- Simplifies the process of service registration and decoration in ASP.NET Core applications.

### Steps to Implement the Decorator Pattern with Scrutor

1. **Define Interface & Base Implementation**:
   - Start with an interface, e.g., `IBasketRepository`, and a base implementation, e.g., `BasketRepository`.

2. **Create Decorator**:
   - Create a decorator class like `CachedBasketRepository` that also implements `IBasketRepository` but adds caching logic.

3. **Register Services with Scrutor**:
   - Use Scrutor in `Program.cs` to first register the base service (`BasketRepository`) and then apply the decorator (`CachedBasketRepository`).

#### Example Code

```csharp
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();
```

## Comparison of Proxy and Decorator Patterns

| Feature                  | Proxy Pattern                                         | Decorator Pattern                                |
|--------------------------|-------------------------------------------------------|--------------------------------------------------|
| **Purpose**              | Controls access to an object                          | Adds functionality to an object dynamically      |
| **Use Cases**            | Lazy loading, access control, logging                 | Runtime behavior extension, enhancing components |
| **Structural Impact**    | Acts as an intermediary, no structural change         | Wraps original object, no structural change      |
| **Instantiation Control**| Proxy manages object instantiation                    | Decorator wraps an existing instance             |
| **Typical Examples**     | Security proxies, network proxies                     | UI enhancements, service extensions              |

## Conclusion

The **Proxy Pattern** is ideal when access control or pre-processing is required before accessing an object, making it useful for scenarios like lazy loading and security checks. The **Decorator Pattern**, on the other hand, is used to dynamically add new behavior or modify existing behavior without altering the object's structure. Both patterns enable flexible design and are valuable in scenarios such as caching, logging, and enhancing functionality in complex software systems.

