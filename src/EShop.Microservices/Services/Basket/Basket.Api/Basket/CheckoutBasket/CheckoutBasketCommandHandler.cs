// <fileheader>
//     <copyright file="CheckoutBasketCommandHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Basket.CheckoutBasket;

/// <summary>
/// Handler for processing the <see cref="CheckoutBasketCommand"/>.
/// This class is responsible for handling the command and executing the checkout logic.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CheckoutBasketCommandHandler"/> class.
/// </remarks>
/// <param name="repository">The basket repository to access basket data.</param>
/// <param name="publishEndpoint">The endpoint for publishing events.</param>
public class CheckoutBasketCommandHandler(
    IBasketRepository repository, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    /// <summary>
    /// Handles the checkout process for the basket.
    /// </summary>
    /// <param name="command">The command containing the basket checkout details.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the checkout process.</returns>
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        // Retrieve the existing basket using the repository
        var basket = await repository.GetBasket(command.BasketCheckoutDto.UserName);
        if (basket == null)
        {
            // Return failure result if basket is not found
            return new CheckoutBasketResult(false);
        }

        // Map the command's BasketCheckoutDto to the event message and set the total price
        var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        // Publish the basket checkout event to RabbitMQ using MassTransit
        await publishEndpoint.Publish(eventMessage, cancellationToken);

        // Delete the basket after successful checkout
        await repository.DeleteBasket(command.BasketCheckoutDto.UserName, cancellationToken);

        // Return success result
        return new CheckoutBasketResult(true);
    }
}

/// <summary>
/// Command to initiate the checkout of a basket.
/// </summary>
/// <param name="BasketCheckoutDto">The DTO containing the basket checkout details.</param>
public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>;

/// <summary>
/// Result of the basket checkout command.
/// </summary>
/// <param name="IsSuccess">Indicates if the checkout was successful.</param>
public record CheckoutBasketResult(bool IsSuccess);