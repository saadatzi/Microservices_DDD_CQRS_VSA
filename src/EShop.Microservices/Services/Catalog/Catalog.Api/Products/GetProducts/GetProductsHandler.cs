// <fileheader>
//     <copyright file="GetProductsHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Catalog.Api.Products.GetProducts;

/// <summary>
/// Handles the creation of a product.
/// </summary>
internal class GetProductsHandler(
    IDocumentSession session)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    /// <summary>
    /// Handles the fetch a product based on the provided Query from the database.
    /// </summary>
    /// <param name="query">The Get product Query.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation and returns the product result.</returns>
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        // return list of products;
        return new GetProductsResult(products);
    }
}

/// <summary>
/// Represents a Query for creating a product.
/// </summary>
public record GetProductsQuery()
    : IQuery<GetProductsResult>;

/// <summary>
/// Represents the result of creating a product.
/// </summary>
public record GetProductsResult(IEnumerable<Product> Products);