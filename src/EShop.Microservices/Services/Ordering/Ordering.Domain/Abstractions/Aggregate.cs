// <fileheader>
//     <copyright file="Aggregate.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Domain.Abstractions;

/// <summary>
/// Abstract class Aggregate&lt;TId&gt; that represents an aggregate root with an identifier and domain events.
/// </summary>
/// <typeparam name="TId">The type of the identifier.</typeparam>
public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    /// <summary>
    /// Private list to hold domain events associated with this aggregate.
    /// </summary>
    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Gets the list of domain events as a read-only collection.
    /// </summary>
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Adds a domain event to the aggregate's event list.
    /// </summary>
    /// <param name="domainEvent">The domain event to be added.</param>
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Clears all domain events from the aggregate and returns them.
    /// </summary>
    /// <returns>An array of <see cref="IDomainEvent"/> representing the cleared domain events.</returns>
    public IDomainEvent[] ClearDomainEvents()
    {
        IDomainEvent[] dequeuedEvents = _domainEvents.ToArray();
        _domainEvents.Clear();
        return dequeuedEvents;
    }
}