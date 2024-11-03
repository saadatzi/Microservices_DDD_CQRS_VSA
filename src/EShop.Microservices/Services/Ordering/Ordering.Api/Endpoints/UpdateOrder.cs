// <fileheader>
//     <copyright file="UpdateOrder.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.API.Endpoints;

/// <summary>
/// UpdateOrder class that implements ICarterModule to define the route and handle the updating of orders.
/// </summary>
public class UpdateOrder : ICarterModule
{
    /// <summary>
    /// Adds the route for updating an order to the application.
    /// </summary>
    /// <param name="app">Endpoint route builder.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Define a PUT endpoint for updating an order
        app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) =>
        {
            // Adapt the request to an UpdateOrderCommand
            var command = request.Adapt<UpdateOrderCommand>();

            // Send the command via MediatR to handle the order update
            var result = await sender.Send(command);

            // Adapt the result to the response format
            var response = result.Adapt<UpdateOrderResponse>();

            // Return a 200 OK response with the update operation's success status
            return Results.Ok(response);
        })
        .WithName("UpdateOrder") // Name the endpoint as "UpdateOrder"
        .Produces<UpdateOrderResponse>(StatusCodes.Status200OK) // Define the response type for 200 OK
        .ProducesProblem(StatusCodes.Status400BadRequest) // Define a possible 400 Bad Request problem response
        .WithSummary("Update Order") // Provide a summary for API documentation
        .WithDescription("Updates an existing order in the system"); // Provide a description for API documentation
    }
}

/// <summary>
/// Represents the request for updating an order, containing an OrderDto object.
/// </summary>
public record UpdateOrderRequest(OrderDto Order);

/// <summary>
/// Represents the response for the update order operation, indicating success status.
/// </summary>
public record UpdateOrderResponse(bool IsSuccess);