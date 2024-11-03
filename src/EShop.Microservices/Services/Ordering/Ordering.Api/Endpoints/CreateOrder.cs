// <fileheader>
//     <copyright file="CreateOrder.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.API.Endpoints;

/// <summary>
/// CreateOrder class that implements ICarterModule to define the route and handle the creation of orders.
/// </summary>
public class CreateOrder : ICarterModule
{
    /// <summary>
    /// Adds the route for creating an order to the application.
    /// </summary>
    /// <param name="app">Endpoint route builder.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Define a POST endpoint for creating an order
        app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
        {
            // Adapt the request to a CreateOrderCommand
            var command = request.Adapt<CreateOrderCommand>();

            // Send the command via MediatR to handle the order creation
            var result = await sender.Send(command);

            // Adapt the result to the response format
            var response = result.Adapt<CreateOrderResponse>();

            // Return a 201 Created response with the created order's ID in the URL and response body
            return Results.Created($"/orders/{response.Id}", response);
        })
        .WithName("CreateOrder") // Name the endpoint as "CreateOrder"
        .Produces<CreateOrderResponse>(StatusCodes.Status201Created) // Define the response type for 201 Created
        .ProducesProblem(StatusCodes.Status400BadRequest) // Define a possible 400 Bad Request problem response
        .WithSummary("Create Order") // Provide a summary for API documentation
        .WithDescription("Creates a new order in the system"); // Provide a description for API documentation
    }
}

/// <summary>
/// Handles the creation of orders via a POST endpoint.
/// </summary>
public record CreateOrderRequest(OrderDto Order);

/// <summary>
/// Response record for Create Order operation, containing the Order ID.
/// </summary>
public record CreateOrderResponse(Guid Id);