// <fileheader>
//     <copyright file="OrderCreatedEventHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Orders.EventHandlers;

/// <summary>
/// Handles the event when an order is created.
/// </summary>
public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
{
    private readonly ILogger<OrderCreatedEventHandler> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderCreatedEventHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger used for logging information.</param>
    public OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
    {
        this.logger = logger;
    }

    /// <summary>
    /// Handles the order created event.
    /// </summary>
    /// <param name="notification">The event notification details.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A completed task once the event handling is done.</returns>
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}