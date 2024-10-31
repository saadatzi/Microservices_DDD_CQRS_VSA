// <fileheader>
//     <copyright file="StoreBasketHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Basket.StoreBasket;

/// <summary>
/// Handles the <see cref="StoreBasketCommand"/> command.
/// </summary>
public class StoreBasketHandler(
    IBasketRepository repository,
    DiscountProtoService.DiscountProtoServiceClient discountProto)
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
        // TODO : communicate with Discount.Grpc and calculate latest price of product
        await DeductDiscount(command.Cart, cancellationToken);
        await repository.StoreBasket(command.Cart, cancellationToken);
        return new StoreBasketResult(command.Cart.UserName);
    }

    /// <summary>
    /// Deducts discounts for each item in the shopping cart by communicating with the Discount.Grpc service.
    /// </summary>
    /// <param name="cart">The shopping cart containing items to which discounts should be applied.</param>
    /// <param name="cancellationToken">Token to observe while waiting for the task to complete.</param>
    private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        // Communicate with Discount.Grpc and calculate latest prices of products in the cart
        foreach (var item in cart.Items)
        {
            // Sending a GetDiscountRequest to the Discount.Grpc service to fetch the discount for each item
            var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);

            // Apply the discount amount retrieved to the item price
            item.Price -= coupon.Amount;
        }
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