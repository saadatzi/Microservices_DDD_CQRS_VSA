// <fileheader>
//     <copyright file="CheckoutBasketEndpoints.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Basket.CheckoutBasket;

/// <summary>
/// Class defining the endpoints for basket checkout.
/// </summary>
public class CheckoutBasketEndpoints : ICarterModule
{
    /// <summary>
    /// Configures the route for checking out a basket.
    /// </summary>
    /// <param name="app">The endpoint route builder.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Define the endpoint for checking out the basket
        app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
        {
            // Adapt the request to a command
            var command = request.Adapt<CheckoutBasketCommand>();

            // Send the command and await the result
            var result = await sender.Send(command);

            // Adapt the result to a response
            var response = result.Adapt<CheckoutBasketResponse>();

            // Return the response as an OK result
            return Results.Ok(response);
        })
        .WithName("CheckoutBasket") // Endpoint name
        .Produces<CheckoutBasketResponse>(StatusCodes.Status201Created) // Expected success response
        .ProducesProblem(StatusCodes.Status400BadRequest) // Possible error response
        .WithSummary("Checkout Basket") // Summary for API documentation
        .WithDescription("Checkout Basket"); // Description for API documentation
    }
}

/// <summary>
/// Request object for checking out the basket.
/// </summary>
/// <param name="BasketCheckoutDto">The basket checkout details in the form of a DTO.</param>
public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckoutDto);

/// <summary>
/// Response object for the basket checkout process.
/// </summary>
/// <param name="IsSuccess">Indicates whether the checkout process was successful.</param>
public record CheckoutBasketResponse(bool IsSuccess);