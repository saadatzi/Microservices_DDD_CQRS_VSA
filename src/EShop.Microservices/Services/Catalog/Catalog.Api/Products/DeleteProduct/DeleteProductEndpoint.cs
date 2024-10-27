// <fileheader>
//     <copyright file="DeleteProductEndpoint.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Catalog.Api.Products.DeleteProduct;

/// <summary>
/// Represents an endpoint for updating a product.
/// </summary>
public class DeleteProductEndpoint : ICarterModule
{
    /// <summary>
    /// Configures the routes for the Update Product endpoint.
    /// </summary>
    /// <param name="app">The <see cref="IEndpointRouteBuilder"/> used to define endpoints.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete(
            "/products/{id}",
            async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));
                var response = result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            })
            .WithName("DeleteProduct")
            .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
    }
}

/// <summary>
/// Represents the response for updating a product.
/// </summary>
public record DeleteProductResponse(bool IsSuccess);