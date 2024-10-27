// <fileheader>
//     <copyright file="CreateProductEndpoint.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Catalog.Api.Products.CreateProduct;

/// <summary>
/// Represents an endpoint for creating a product.
/// </summary>
public class CreateProductEndpoint : ICarterModule
{
    /// <summary>
    /// Configures the routes for the Create Product endpoint.
    /// </summary>
    /// <param name="app">The <see cref="IEndpointRouteBuilder"/> used to define endpoints.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/products",
            async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);
            })

            // Sets the name of the endpoint to "CreateProduct", allowing it to be referenced by name elsewhere in the code (e.g., for link generation).
            .WithName("CreateProduct")

            // Specifies that, on successful creation, this endpoint will return a 201 Created status code along with a response of type CreateProductResponse.
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)

            // Indicates that if there's a problem (e.g., a bad request), the endpoint will return a 400 Bad Request status code, along with a standardized problem response.
            .ProducesProblem(StatusCodes.Status400BadRequest)

            // Provides a brief summary of the endpoint, typically used by documentation tools (e.g., Swagger) to give a short description of what the endpoint does.
            .WithSummary("Create Product")

            // Gives a more detailed description of the endpoint, which is also used by documentation tools to provide further information about the endpoint's purpose.
            .WithDescription("Create Product");
    }
}

/// <summary>
/// Represents the request for creating a product.
/// </summary>
public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

/// <summary>
/// Represents the response for creating a product.
/// </summary>
public record CreateProductResponse(Guid Id);