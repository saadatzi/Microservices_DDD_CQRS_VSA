// <fileheader>
//     <copyright file="GetBasketEndpoints.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Basket.API.Basket.GetBasket;

/// <summary>
/// Defines the endpoints for handling basket-related requests.
/// </summary>
public class GetBasketEndpoints : ICarterModule
{
    /// <summary>
    /// Adds the routes for the basket endpoints.
    /// </summary>
    /// <param name="app">The endpoint route builder.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));
            var response = result.Adapt<GetBasketResponse>();
            return Results.Ok(response);
        })
        .WithName("GetProductById")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}

/// <summary>
/// Represents the response model for getting a basket.
/// </summary>
/// <param name="Cart">The shopping cart associated with the basket.</param>
public record GetBasketResponse(ShoppingCart Cart);