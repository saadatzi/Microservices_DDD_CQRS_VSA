// <fileheader>
//     <copyright file="UpdateProductEndpoint.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Catalog.Api.Products.UpdateProduct;

/// <summary>
/// Represents an endpoint for updating a product.
/// </summary>
public class UpdateProductEndpoint : ICarterModule
{
    /// <summary>
    /// Configures the routes for the Update Product endpoint.
    /// </summary>
    /// <param name="app">The <see cref="IEndpointRouteBuilder"/> used to define endpoints.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut(
            "/products",
            async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateProduct")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
    }
}

/// <summary>
/// Represents the request for updating a product.
/// </summary>
public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

/// <summary>
/// Represents the response for updating a product.
/// </summary>
public record UpdateProductResponse(bool IsSuccess);