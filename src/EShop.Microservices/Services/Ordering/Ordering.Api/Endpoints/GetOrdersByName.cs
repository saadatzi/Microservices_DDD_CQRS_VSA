// <fileheader>
//     <copyright file="GetOrdersByName.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.API.Endpoints;

/// <summary>
/// GetOrdersByName class that implements ICarterModule to define the route and handle retrieving orders by name.
/// </summary>
public class GetOrdersByName : ICarterModule
{
    /// <summary>
    /// Adds the route for retrieving orders by name to the application.
    /// </summary>
    /// <param name="app">Endpoint route builder.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Define a GET endpoint for retrieving orders by name
        app.MapGet("/orders/{orderName}", async (string orderName, ISender sender) =>
        {
            // Send the GetOrdersByNameQuery with the provided order name via MediatR
            var result = await sender.Send(new GetOrdersByNameQuery(orderName));

            // Adapt the result to the response format
            var response = result.Adapt<GetOrdersByNameResponse>();

            // Return a 200 OK response with the list of matching orders
            return Results.Ok(response);
        })
        .WithName("GetOrdersByName") // Name the endpoint as "GetOrdersByName"
        .Produces<GetOrdersByNameResponse>(StatusCodes.Status200OK) // Define the response type for 200 OK
        .ProducesProblem(StatusCodes.Status400BadRequest) // Define a possible 400 Bad Request problem response
        .ProducesProblem(StatusCodes.Status404NotFound) // Define a possible 404 Not Found problem response
        .WithSummary("Get Orders By Name") // Provide a summary for API documentation
        .WithDescription("Retrieves orders matching the specified order name."); // Provide a description for API documentation
    }
}

/// <summary>
/// Represents the response for the GetOrdersByName operation, containing a collection of orders matching the specified name.
/// </summary>
public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);