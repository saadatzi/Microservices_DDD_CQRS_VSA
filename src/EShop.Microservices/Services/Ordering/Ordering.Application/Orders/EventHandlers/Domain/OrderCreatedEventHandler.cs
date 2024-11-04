// <fileheader>
//     <copyright file="OrderCreatedEventHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.FeatureManagement;

namespace Ordering.Application.Orders.EventHandlers;

/// <summary>
/// Handles the event when an order is created.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="OrderCreatedEventHandler"/> class.
/// </remarks>
/// <param name="logger">The logger used for logging information.</param>
/// <param name="publishEndpoint">The publishEndpoint used for determine which endpoint the message sent.</param>
/// <param name="featureManager">The featureManager used to check whether a feature is enable or not. the value has been set in appsetting.json.</param>
public class OrderCreatedEventHandler(
    IPublishEndpoint publishEndpoint, IFeatureManager featureManager, ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    private readonly ILogger<OrderCreatedEventHandler> logger = logger;

    /// <summary>
    /// Handles the order created event.
    /// </summary>
    /// <param name="domainEvent">The event notification details.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A completed task once the event handling is done.</returns>
    public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);
        if (await featureManager.IsEnabledAsync("OrderFulFillment"))
        {
            var orderCreatedIntegrationEvent = domainEvent.Order.ToOrderDto();
            await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
        }
    }
}