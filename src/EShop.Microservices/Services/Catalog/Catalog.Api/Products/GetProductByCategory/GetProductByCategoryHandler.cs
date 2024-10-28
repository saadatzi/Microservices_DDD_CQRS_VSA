// <fileheader>
//     <copyright file="GetProductByCategoryHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Catalog.Api.Products.GetProductByCategory;

/// <summary>
/// Handles queries to retrieve products by category.
/// </summary>
/// <param name="session">The document session for database operations.</param>
internal class GetProductByCategoryHandler(
    IDocumentSession session)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    /// <summary>
    /// Handles the query to get products by category.
    /// </summary>
    /// <param name="query">The query containing the category filter.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>A result containing a list of products in the specified category.</returns>
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        // Retrieve products from the specified category.
        var products = await session.Query<Product>()
            .Where(p => p.Category.Any(c => c.Contains(query.Category)))
            .ToListAsync(cancellationToken);

        // Return the list of products.
        return new GetProductByCategoryResult(products);
    }
}

/// <summary>
/// Represents a query to retrieve products by category.
/// </summary>
/// <param name="Category">The category to filter products by.</param>
public record GetProductByCategoryQuery(string Category)
    : IQuery<GetProductByCategoryResult>;

/// <summary>
/// Represents the result of a query to retrieve products by category.
/// </summary>
/// <param name="Products">A collection of products in the specified category.</param>
public record GetProductByCategoryResult(IEnumerable<Product> Products);