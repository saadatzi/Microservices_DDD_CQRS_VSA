// <fileheader>
//     <copyright file="StoreBasketHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Basket.StoreBasket;

/// <summary>
/// Handles the <see cref="StoreBasketCommand"/> command.
/// </summary>
public class StoreBasketHandler(IBasketRepository basketRepository)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    /// <summary>
    /// Handles the command to store a shopping cart.
    /// </summary>
    /// <param name="command">The command containing the shopping cart to be stored.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation, with the result of storing the shopping cart.</returns>
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart = command.Cart;

        // TODO: Store basket in database (use Marten upsert - if exist, update; if not, create)
        // TODO: Update cache
        await basketRepository.StoreBasket(cart, cancellationToken);
        return new StoreBasketResult(cart.UserName);
    }
}

/// <summary>
/// Represents a command to store a shopping cart.
/// </summary>
/// <param name="Cart">The shopping cart to be stored.</param>
public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

/// <summary>
/// Represents the result of storing a shopping cart.
/// </summary>
/// <param name="UserName">The username associated with the stored shopping cart.</param>
public record StoreBasketResult(string UserName);