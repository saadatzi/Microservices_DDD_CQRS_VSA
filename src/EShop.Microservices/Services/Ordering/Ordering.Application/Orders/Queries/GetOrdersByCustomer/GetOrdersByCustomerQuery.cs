// <fileheader>
//     <copyright file="GetOrdersByCustomerQuery.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

/// <summary>
/// Represents a query to get orders for a specific customer.
/// </summary>
/// <param name="CustomerId">The ID of the customer whose orders are being retrieved.</param>
public record GetOrdersByCustomerQuery(Guid CustomerId) : IQuery<GetOrdersByCustomerResult>;

/// <summary>
/// Represents the result of the <see cref="GetOrdersByCustomerQuery"/>.
/// </summary>
/// <param name="Orders">The list of orders associated with the specified customer.</param>
public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);