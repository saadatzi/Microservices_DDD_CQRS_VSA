// <fileheader>
//     <copyright file="GetOrdersByNameQuery.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Orders.Queries.GetOrdersByName;

/// <summary>
/// Represents a query to retrieve orders by a specific name.
/// </summary>
/// <param name="Name">The name associated with the orders to retrieve.</param>
public record GetOrdersByNameQuery(string Name) : IQuery<GetOrdersByNameResult>;

/// <summary>
/// Represents the result of the <see cref="GetOrdersByNameQuery"/>, containing a collection of orders.
/// </summary>
/// <param name="Orders">The collection of orders that match the specified name.</param>
public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);