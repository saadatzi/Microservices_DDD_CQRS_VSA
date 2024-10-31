// <fileheader>
//     <copyright file="OrderUpdatedEvent.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

using Ordering.Domain.Models;

namespace Ordering.Domain.Events;

/// <summary>
/// Represents an event that occurs when an order has been updated.
/// This event is part of the domain events in the Ordering domain and
/// implements the <see cref="IDomainEvent"/> interface to notify other parts
/// of the domain model that the order's state has changed.
/// </summary>
/// <param name="Order">The updated order instance that triggered this event.</param>
public record OrderUpdatedEvent(Order Order) : IDomainEvent;