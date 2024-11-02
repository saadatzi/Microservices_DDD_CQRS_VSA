// <fileheader>
//     <copyright file="GetOrdersQuery.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;

/// <summary>
/// Query for retrieving paginated orders.
/// </summary>
/// <param name="PaginationRequest">The pagination parameters for the query.</param>
public record GetOrdersQuery(PaginationRequest PaginationRequest) : IQuery<GetOrdersResult>;

/// <summary>
/// Represents the result of a GetOrdersQuery, containing a paginated list of orders.
/// </summary>
/// <param name="Orders">The paginated result of orders.</param>
public record GetOrdersResult(PaginatedResult<OrderDto> Orders);