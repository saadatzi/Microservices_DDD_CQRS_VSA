// <fileheader>
//     <copyright file="StoreBasketEndpoints.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Basket.API.Basket.StoreBasket;

/// <summary>
/// Defines the endpoints related to basket storage.
/// Implements <see cref="ICarterModule"/> for routing.
/// </summary>
public class StoreBasketEndpoints : ICarterModule
{
    /// <summary>
    /// Adds the routing for the StoreBasket endpoints.
    /// </summary>
    /// <param name="app">The endpoint route builder.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<StoreBasketCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<StoreBasketResponse>();

            return Results.Created($"/basket/{response.UserName}", response);
        })
        .WithName("CreateProduct")
        .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}

/// <summary>
/// Represents the request to store a basket.
/// </summary>
/// <param name="Cart">The shopping cart to be stored.</param>
public record StoreBasketRequest(ShoppingCart Cart);

/// <summary>
/// Represents the response for storing a basket.
/// </summary>
/// <param name="UserName">The username associated with the stored shopping cart.</param>
public record StoreBasketResponse(string UserName);