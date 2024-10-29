// <fileheader>
//     <copyright file="BasketRepository.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Data;

/// <summary>
/// Repository for managing basket operations.
/// Implements the IBasketRepository interface for accessing and modifying basket data.
/// </summary>
public class BasketRepository(IDocumentSession session)
    : IBasketRepository
{
    /// <summary>
    /// Retrieves a shopping cart associated with the specified username.
    /// </summary>
    /// <param name="userName">The username associated with the shopping cart.</param>
    /// <param name="cancellationToken">A cancellation token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the user's shopping cart.</returns>
    /// <exception cref="BasketNotFoundException">Thrown when the basket is not found.</exception>
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken)
    {
        var basket = await session.LoadAsync<ShoppingCart>(userName, cancellationToken);
        return basket is null ? throw new BasketNotFoundException(userName) : basket;
    }

    /// <summary>
    /// Stores a shopping cart in the data store.
    /// </summary>
    /// <param name="basket">The shopping cart to be stored.</param>
    /// <param name="cancellationToken">A cancellation token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the stored shopping cart.</returns>
    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken)
    {
        session.Store(basket);
        await session.SaveChangesAsync(cancellationToken);
        return basket;
    }

    /// <summary>
    /// Deletes a shopping cart associated with the specified username.
    /// </summary>
    /// <param name="userName">The username whose shopping cart should be deleted.</param>
    /// <param name="cancellationToken">A cancellation token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, returning true if the deletion was successful; otherwise, false.</returns>
    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        session.Delete<ShoppingCart>(userName);
        await session.SaveChangesAsync(cancellationToken);
        return true;
    }
}