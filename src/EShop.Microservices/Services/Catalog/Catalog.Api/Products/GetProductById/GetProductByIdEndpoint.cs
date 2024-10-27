// <fileheader>
//     <copyright file="GetProductByIdEndpoint.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Catalog.Api.Products.GetProductById;

/// <summary>
/// Represents an endpoint for creating a product.
/// </summary>
public class GetProductByIdEndpoint : ICarterModule
{
    /// <summary>
    /// Configures the routes for the Get Product endpoint.
    /// </summary>
    /// <param name="app">The <see cref="IEndpointRouteBuilder"/> used to define endpoints.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/products/{id}",
            async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Products By Id");
    }
}

// public record GetProductByIdRequest(Guid Id);

/// <summary>
/// Represents the response for creating a product.
/// </summary>
public record GetProductByIdResponse(Product Product);