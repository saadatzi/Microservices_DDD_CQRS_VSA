// <fileheader>
//     <copyright file="DeleteOrder.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.API.Endpoints;

/// <summary>
/// DeleteOrder class that implements ICarterModule to define the route and handle the deletion of orders.
/// </summary>
public class DeleteOrder : ICarterModule
{
    /// <summary>
    /// Adds the route for deleting an order to the application.
    /// </summary>
    /// <param name="app">Endpoint route builder.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Define a DELETE endpoint for deleting an order by ID
        app.MapDelete("/orders/{id}", async (Guid id, ISender sender) =>
        {
            // Send the DeleteOrderCommand with the provided order ID via MediatR
            var result = await sender.Send(new DeleteOrderCommand(id));

            // Adapt the result to the response format
            var response = result.Adapt<DeleteOrderResponse>();

            // Return a 200 OK response with the delete operation's success status
            return Results.Ok(response);
        })
        .WithName("DeleteOrder") // Name the endpoint as "DeleteOrder"
        .Produces<DeleteOrderResponse>(StatusCodes.Status200OK) // Define the response type for 200 OK
        .ProducesProblem(StatusCodes.Status400BadRequest) // Define a possible 400 Bad Request problem response
        .ProducesProblem(StatusCodes.Status404NotFound) // Define a possible 404 Not Found problem response
        .WithSummary("Delete Order") // Provide a summary for API documentation
        .WithDescription("Deletes an existing order from the system"); // Provide a description for API documentation
    }
}

/// <summary>
/// Represents the response for the delete order operation, indicating success status.
/// </summary>
public record DeleteOrderResponse(bool IsSuccess);