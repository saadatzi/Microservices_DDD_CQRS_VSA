// <fileheader>
//     <copyright file="IAggregate.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Domain.Abstractions;

/// <summary>
/// Generic interface IAggregate&lt;T&gt; representing an aggregate root with an identifier and domain events.
/// </summary>
/// <typeparam name="T">The type of the identifier.</typeparam>
public interface IAggregate<T> : IAggregate, IEntity<T>
{
}

/// <summary>
/// Interface IAggregate representing an aggregate root in the domain.
/// </summary>
public interface IAggregate : IEntity
{
    /// <summary>
    /// Gets the list of domain events associated with the aggregate.
    /// </summary>
    /// <returns>An IReadOnlyList of <see cref="IDomainEvent"/> representing the domain events.</returns>
    IReadOnlyList<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Clears all domain events from the aggregate.
    /// </summary>
    /// <returns>An array of <see cref="IDomainEvent"/> representing the cleared domain events.</returns>
    IDomainEvent[] ClearDomainEvents();
}