// <fileheader>
//     <copyright file="IBasketRepository.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Data;

/// <summary>
/// Defines the contract for the Basket Repository.
/// This interface outlines the methods required for managing basket data operations.
/// </summary>
public interface IBasketRepository
{
    /// <summary>
    /// Retrieves a shopping cart based on the provided username.
    /// </summary>
    /// <param name="userName">The username associated with the shopping cart.</param>
    /// <param name="cancellationToken">A cancellation token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the user's shopping cart.</returns>
    Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken);

    /// <summary>
    /// Stores a shopping cart in the data store.
    /// </summary>
    /// <param name="basket">The shopping cart to be stored.</param>
    /// <param name="cancellationToken">A cancellation token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the stored shopping cart.</returns>
    Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a shopping cart associated with the specified username.
    /// </summary>
    /// <param name="userName">The username whose shopping cart should be deleted.</param>
    /// <param name="cancellationToken">A cancellation token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, returning true if the deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);
}