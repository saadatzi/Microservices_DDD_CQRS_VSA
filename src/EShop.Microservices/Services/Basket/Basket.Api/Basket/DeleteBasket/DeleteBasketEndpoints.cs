// <fileheader>
//     <copyright file="DeleteBasketEndpoints.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Basket.API.Basket.DeleteBasket;

/// <summary>
/// Defines the endpoints for deleting a basket.
/// Implements the <see cref="ICarterModule"/> interface.
/// </summary>
public class DeleteBasketEndpoints : ICarterModule
{
    /// <summary>
    /// Adds the delete basket routes to the application.
    /// </summary>
    /// <param name="app">The endpoint route builder.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBasketCommand(userName));
            var response = result.Adapt<DeleteBasketResponse>();
            return Results.Ok(response);
        })
        .WithName("DeleteProduct")
        .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }
}

/// <summary>
/// Represents the request to delete a basket.
/// </summary>
/// <param name="UserName">The username associated with the basket to be deleted.</param>
public record DeleteBasketRequest(string UserName);

/// <summary>
/// Represents the response for the delete basket operation.
/// </summary>
/// <param name="IsSuccess">Indicates whether the delete operation was successful.</param>
public record DeleteBasketResponse(bool IsSuccess);