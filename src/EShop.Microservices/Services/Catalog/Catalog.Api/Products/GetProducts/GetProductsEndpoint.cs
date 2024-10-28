// <fileheader>
//     <copyright file="GetProductsEndpoint.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Catalog.Api.Products.GetProducts;

/// <summary>
/// Represents an endpoint for creating a product.
/// </summary>
public class GetProductsEndpoint : ICarterModule
{
    /// <summary>
    /// Configures the routes for the Get Product endpoint.
    /// </summary>
    /// <param name="app">The <see cref="IEndpointRouteBuilder"/> used to define endpoints.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/products",
            async ([AsParameters] GetProductRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsQuery>();
                var result = await sender.Send(query);
                var response = result.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
    }
}

/// <summary>
/// Represents a request to get a list of products with pagination.
/// </summary>
/// <param name="PageNumber">The page number for pagination. Default is 1.</param>
/// <param name="PageSize">The number of items per page for pagination. Default is 10.</param>

public record GetProductRequest(int? PageNumber = 1, int? PageSize = 10);

/// <summary>
/// Represents the response for creating a product.
/// </summary>
public record GetProductsResponse(IEnumerable<Product> Products);