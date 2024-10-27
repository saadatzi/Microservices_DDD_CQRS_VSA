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
            async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
    }
}

// public record GetProductRequest();

/// <summary>
/// Represents the response for creating a product.
/// </summary>
public record GetProductResponse(IEnumerable<Product> Products);