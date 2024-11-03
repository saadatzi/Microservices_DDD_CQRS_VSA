// <fileheader>
//     <copyright file="GetOrders.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Api.Endpoints;

/// <summary>
/// Configures the GetOrders API endpoint in the Ordering service.
/// </summary>
public class GetOrders : ICarterModule
{
    /// <summary>
    /// Configures the API routes for the GetOrders endpoint.
    /// </summary>
    /// <param name="app">The application's endpoint route builder.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            // Sends the GetOrdersQuery with pagination parameters
            var result = await sender.Send(new GetOrdersQuery(request));

            // Adapts the result to a GetOrdersResponse format
            var response = result.Adapt<GetOrdersResponse>();

            // Returns the response with an OK status code
            return Results.Ok(response);
        })
        .WithName("GetOrders")
        .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders")
        .WithDescription("Retrieves a paginated list of orders based on the given pagination parameters.");
    }
}

/// <summary>
/// Defines the GetOrders request and response records and configures the GetOrders API endpoint.
/// </summary>
public record GetOrdersRequest(PaginationRequest PaginationRequest);

/// <summary>
/// Represents the response structure for the GetOrders endpoint.
/// </summary>
/// <param name="Orders">The paginated result containing a list of OrderDto objects.</param>
public record GetOrdersResponse(PaginatedResult<OrderDto> Orders);