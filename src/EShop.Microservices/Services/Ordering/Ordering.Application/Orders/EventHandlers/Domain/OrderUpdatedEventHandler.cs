// <fileheader>
//     <copyright file="OrderUpdatedEventHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Orders.EventHandlers;

/// <summary>
/// Handles the event when an order is updated.
/// </summary>
public class OrderUpdatedEventHandler : INotificationHandler<OrderUpdatedEvent>
{
    private readonly ILogger<OrderUpdatedEventHandler> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderUpdatedEventHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger used for logging information.</param>
    public OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger)
    {
        this.logger = logger;
    }

    /// <summary>
    /// Handles the order updated event.
    /// </summary>
    /// <param name="notification">The event notification details.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A completed task once the event handling is done.</returns>
    public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}