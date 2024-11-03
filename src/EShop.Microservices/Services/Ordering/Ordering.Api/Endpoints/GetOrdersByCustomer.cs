// <fileheader>
//     <copyright file="GetOrdersByCustomer.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.API.Endpoints;

/// <summary>
/// GetOrdersByCustomer class that implements ICarterModule to define the route and handle retrieving orders by customer ID.
/// </summary>
public class GetOrdersByCustomer : ICarterModule
{
    /// <summary>
    /// Adds the route for retrieving orders by customer ID to the application.
    /// </summary>
    /// <param name="app">Endpoint route builder.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Define a GET endpoint for retrieving orders by customer ID
        app.MapGet("/orders/customer/{customerId}", async (Guid customerId, ISender sender) =>
        {
            // Send the GetOrdersByCustomerQuery with the provided customer ID via MediatR
            var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));

            // Adapt the result to the response format
            var response = result.Adapt<GetOrdersByCustomerResponse>();

            // Return a 200 OK response with the list of orders for the specified customer
            return Results.Ok(response);
        })
        .WithName("GetOrdersByCustomer") // Name the endpoint as "GetOrdersByCustomer"
        .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK) // Define the response type for 200 OK
        .ProducesProblem(StatusCodes.Status400BadRequest) // Define a possible 400 Bad Request problem response
        .ProducesProblem(StatusCodes.Status404NotFound) // Define a possible 404 Not Found problem response
        .WithSummary("Get Orders By Customer") // Provide a summary for API documentation
        .WithDescription("Retrieves orders for the specified customer ID."); // Provide a description for API documentation
    }
}

/// <summary>
/// Represents the response for the GetOrdersByCustomer operation, containing a collection of orders for a specific customer.
/// </summary>
public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);