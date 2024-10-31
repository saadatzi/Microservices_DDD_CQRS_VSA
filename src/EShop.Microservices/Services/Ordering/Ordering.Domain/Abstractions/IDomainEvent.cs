// <fileheader>
//     <copyright file="IDomainEvent.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

using MediatR;

namespace Ordering.Domain.Abstractions;

/// <summary>
/// Represents a domain event that implements the MediatR INotification interface.
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// Gets a unique identifier for the event.
    /// </summary>
    Guid EventId => Guid.NewGuid();

    /// <summary>
    /// Gets the date and time when the event occurred.
    /// </summary>
    public DateTime OccurredOn => DateTime.Now;

    /// <summary>
    /// Gets the fully qualified name of the event's type.
    /// </summary>
    public string EventType => GetType().AssemblyQualifiedName!;
}