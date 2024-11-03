// <fileheader>
//     <copyright file="PaginatedResult.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace BuildingBlocks.Pagination;

/// <summary>
/// Represents a paginated result that contains a subset of data for a specific page, along with metadata about the pagination.
/// </summary>
/// <typeparam name="TEntity">The type of the entities in the data collection.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="PaginatedResult{TEntity}"/> class.
/// </remarks>
/// <param name="pageIndex">The index of the current page.</param>
/// <param name="pageSize">The number of items in each page.</param>
/// <param name="count">The total number of items available across all pages.</param>
/// <param name="data">The collection of data for the current page.</param>
public class PaginatedResult<TEntity>(
    int pageIndex,
    int pageSize,
    long count,
    IEnumerable<TEntity> data)
    where TEntity : class
{
    /// <summary>
    /// Gets the index of the current page.
    /// </summary>
    public int PageIndex { get; } = pageIndex;

    /// <summary>
    /// Gets the number of items in each page.
    /// </summary>
    public int PageSize { get; } = pageSize;

    /// <summary>
    /// Gets the total number of items available across all pages.
    /// </summary>
    public long Count { get; } = count;

    /// <summary>
    /// Gets the collection of data for the current page.
    /// </summary>
    public IEnumerable<TEntity> Data { get; } = data;
}