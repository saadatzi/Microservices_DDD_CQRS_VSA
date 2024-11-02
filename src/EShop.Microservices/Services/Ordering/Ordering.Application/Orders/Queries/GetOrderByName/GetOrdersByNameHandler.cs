// <fileheader>
//     <copyright file="GetOrdersByNameHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Orders.Queries.GetOrderByName;

/// <summary>
/// Handler for processing the <see cref="GetOrdersByNameQuery"/> to retrieve orders by name.
/// </summary>
public class GetOrdersByNameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
{
    /// <summary>
    /// Handles the query to retrieve orders by name.
    /// </summary>
    /// <param name="query">The query containing the order name to search for.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the retrieved orders.</returns>
    public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
    {
        // Get orders by name using dbContext
        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .Where(o => o.OrderName.Value.Contains(query.Name))
            .OrderBy(o => o.OrderName)
            .ToListAsync(cancellationToken);

        // Return the result
        return new GetOrdersByNameResult(orders.ToOrderDtoList());
    }
}