// <fileheader>
//     <copyright file="GetProductByIdHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Catalog.Api.Products.GetProductById;

using Catalog.Api.Exceptions;

/// <summary>
/// Handles the creation of a product.
/// </summary>
internal class GetProductByIdHandler(
    IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    /// <summary>
    /// Handles the retrieval of a product by its ID.
    /// </summary>
    /// <param name="query">The query object containing the product ID to retrieve.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="GetProductByIdResult"/> containing the product data if found.</returns>
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product == null)
        {
            throw new ProductNotFoundException(query.Id);
        }

        // return the product;
        return new GetProductByIdResult(product);
    }
}

/// <summary>
/// Represents a Query for creating a product.
/// </summary>
public record GetProductByIdQuery(Guid Id)
    : IQuery<GetProductByIdResult>;

/// <summary>
/// Represents the result of creating a product.
/// </summary>
public record GetProductByIdResult(Product? Product);