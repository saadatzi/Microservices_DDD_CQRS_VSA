// <fileheader>
//     <copyright file="GetOrdersByCustomerHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

/// <summary>
/// Handler for processing the <see cref="GetOrdersByCustomerQuery"/> to retrieve orders for a specific customer.
/// </summary>
public class GetOrdersByCustomerHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
{
    /// <summary>
    /// Handles the retrieval of orders by customer.
    /// </summary>
    /// <param name="query">The query containing the customer ID.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result with the list of orders.</returns>
    public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
    {
        // Get orders by customer using dbContext
        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
            .OrderBy(o => o.OrderName.Value)
            .ToListAsync(cancellationToken);

        // Return result
        return new GetOrdersByCustomerResult(orders.ToOrderDtoList());
    }
}