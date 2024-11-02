// <fileheader>
//     <copyright file="GetOrdersHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Orders.Queries.GetOrders;

/// <summary>
/// Handler for processing the <see cref="GetOrdersQuery"/> to retrieve paginated orders.
/// </summary>
public class GetOrdersHandler : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    private readonly IApplicationDbContext dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetOrdersHandler"/> class.
    /// </summary>
    /// <param name="dbContext">The application database context.</param>
    public GetOrdersHandler(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <summary>
    /// Handles the retrieval of paginated orders.
    /// </summary>
    /// <param name="query">The query containing pagination parameters.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of paginated orders.</returns>
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        // Extract pagination parameters from the query
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        // Calculate the total number of records for pagination
        var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);

        // Retrieve the paginated list of orders with related data
        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)
            .OrderBy(o => o.OrderName.Value)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        // Convert the orders to the data transfer object format
        var orderDtos = orders.ToOrderDtoList();

        // Return the paginated result with metadata
        return new GetOrdersResult(
            new PaginatedResult<OrderDto>(
                pageIndex,
                pageSize,
                totalCount,
                orderDtos));
    }
}