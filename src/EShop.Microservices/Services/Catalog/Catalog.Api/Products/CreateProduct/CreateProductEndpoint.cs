// <fileheader>
//     <copyright file="CreateProductEndpoint.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

using Carter;

namespace Catalog.Api.Products.CreateProduct;

/// <summary>
/// Represents an endpoint for creating a product.
/// </summary>
public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        throw new NotImplementedException();
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