// <fileheader>
//     <copyright file="OrderCreatedEvent.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

using Ordering.Domain.Models;

namespace Ordering.Domain.Events;

/// <summary>
/// Represents an event that occurs when an order has been created.
/// This event is part of the domain events in the Ordering domain and
/// implements the <see cref="IDomainEvent"/> interface to notify other parts
/// of the domain model that a new order has been created.
/// </summary>
/// <param name="Order">The created order instance that triggered this event.</param>
public record OrderCreatedEvent(Order Order) : IDomainEvent;