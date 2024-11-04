// <fileheader>
//     <copyright file="BasketCheckoutEventHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration;

/// <summary>
/// Event handler that processes the BasketCheckoutEvent, creating a new order based on the basket information.
/// </summary>
public class BasketCheckoutEventHandler(
    ISender sender, ILogger<BasketCheckoutEventHandler> logger)
    : IConsumer<BasketCheckoutEvent>
{
    /// <summary>
    /// Consumes the BasketCheckoutEvent and initiates the order creation process.
    /// </summary>
    /// <param name="context">The consume context containing the BasketCheckoutEvent message.</param>
    /// <returns>A Task that represents the asynchronous operation.</returns>
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event handled: {IntegrationEventId}", context.Message.Id);

        // Map the event data to the CreateOrderCommand and send it to initiate order creation
        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command);
    }

    /// <summary>
    /// Maps the BasketCheckoutEvent data to CreateOrderCommand.
    /// </summary>
    /// <param name="message">The BasketCheckoutEvent message.</param>
    /// <returns>A CreateOrderCommand with the mapped data.</returns>
    private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        // Create full order with incoming event data
        var addressDto = new AddressDto(
            message.FirstName,
            message.LastName,
            message.EmailAddress,
            message.AddressLine,
            message.Country,
            message.State,
            message.ZipCode);

        var paymentDto = new PaymentDto(
            message.CardName,
            message.CardNumber,
            message.Expiration,
            message.CVV,
            message.PaymentMethod);

        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto(
            Id: orderId,
            CustomerId: message.CustomerId,
            OrderName: message.UserName,
            ShippingAddress: addressDto,
            BillingAddress: addressDto,
            Payment: paymentDto,
            Status: OrderStatus.Pending,
            OrderItems: new List<OrderItemDto>
            {
                new(orderId, new Guid("5334c996-8457-4cf0-815c-ed2b77c4906a"), 2, 500),
                new(orderId, new Guid("c67d6323-e8b1-4bdf-9a75-b0dd2ef3cd6c"), 1, 400),
            });

        return new CreateOrderCommand(orderDto);
    }
}