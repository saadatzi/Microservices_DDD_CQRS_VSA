// <fileheader>
//     <copyright file="CachedBasketRepository.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Data;

using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

/// <summary>
/// Implements a cached repository for managing shopping cart data.
/// This repository acts as a decorator around the original <see cref="IBasketRepository"/>,
/// allowing for additional caching functionality if extended in the future.
/// </summary>
public class CachedBasketRepository
    (IBasketRepository repository, IDistributedCache cache)
    : IBasketRepository
{
    /// <summary>
    /// Retrieves the shopping cart associated with the specified username asynchronously.
    /// </summary>
    /// <param name="userName">The username associated with the shopping cart.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task representing the operation, containing the shopping cart for the specified user.</returns>
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken)
    {
        var cachedBasket = await cache.GetStringAsync(userName, cancellationToken);
        if (!string.IsNullOrEmpty(cachedBasket))
        {
            return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;
        }

        var basket = await repository.GetBasket(userName, cancellationToken);
        await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);
        return basket;
    }

    /// <summary>
    /// Stores or updates a shopping cart asynchronously.
    /// </summary>
    /// <param name="basket">The shopping cart to store or update.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task representing the operation, containing the updated shopping cart.</returns>
    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken)
    {
        await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);
        return await repository.StoreBasket(basket, cancellationToken);
    }

    /// <summary>
    /// Deletes the shopping cart associated with the specified username asynchronously.
    /// </summary>
    /// <param name="userName">The username associated with the shopping cart to delete.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task representing the operation, containing a boolean result indicating whether the delete operation was successful.</returns>
    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken)
    {
        await cache.RemoveAsync(userName, cancellationToken);
        return await repository.DeleteBasket(userName, cancellationToken);
    }
}