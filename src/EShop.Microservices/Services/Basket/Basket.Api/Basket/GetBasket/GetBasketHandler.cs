// <fileheader>
//     <copyright file="GetBasketHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Basket.GetBasket;

/// <summary>
/// Handler for processing <see cref="GetBasketQuery"/> requests.
/// </summary>
public class GetBasketHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    private readonly IBasketRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetBasketHandler"/> class.
    /// </summary>
    /// <param name="repository">The repository for accessing basket data.</param>
    public GetBasketHandler(IBasketRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the retrieval of a user's shopping basket.
    /// </summary>
    /// <param name="query">The request containing the username.</param>
    /// <param name="cancellationToken">The cancellation token for async operations.</param>
    /// <returns>The result containing the shopping cart associated with the user.</returns>
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        // Retrieve the shopping basket from the repository
        var basket = await _repository.GetBasket(query.UserName);
        return new GetBasketResult(basket ?? new ShoppingCart(query.UserName)); // Return a new cart if none found
    }
}

/// <summary>
/// Represents a query to get the shopping basket for a specific user.
/// </summary>
/// <param name="UserName">The username for which to retrieve the shopping basket.</param>
public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

/// <summary>
/// Represents the result of a basket query, containing the shopping cart details.
/// </summary>
/// <param name="Cart">The shopping cart associated with the user.</param>
public record GetBasketResult(ShoppingCart Cart);