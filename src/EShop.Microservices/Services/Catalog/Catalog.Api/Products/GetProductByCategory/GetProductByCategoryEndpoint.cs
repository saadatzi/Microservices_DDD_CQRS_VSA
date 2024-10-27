// <fileheader>
//     <copyright file="GetProductByCategoryEndpoint.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Catalog.Api.Products.GetProductByCategory;

/// <summary>
/// Defines the endpoint to retrieve products by category.
/// </summary>
public class GetProductByCategoryEndpoint : ICarterModule
{
    /// <summary>
    /// Configures the routes for the GetProductByCategory endpoint.
    /// </summary>
    /// <param name="app">The endpoint route builder used to define routes.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/products/category/{category}",
            async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));
                var response = result.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductByCategory")
            .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Category")
            .WithDescription("Get Product By Category");
    }
}

/// <summary>
/// Represents the response containing a list of products by category.
/// </summary>
/// <param name="Products">The collection of products in the specified category.</param>
public record GetProductByCategoryResponse(IEnumerable<Product> Products);