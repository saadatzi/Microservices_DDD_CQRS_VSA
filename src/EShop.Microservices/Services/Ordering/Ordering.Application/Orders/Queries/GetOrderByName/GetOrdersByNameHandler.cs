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

        // Map orders to OrderDto objects
        var orderDtos = ProjectToOrderDto(orders);

        // Return the result
        return new GetOrdersByNameResult(orderDtos);
    }

    /// <summary>
    /// Maps a list of <see cref="Order"/> objects to a list of <see cref="OrderDto"/> objects.
    /// </summary>
    /// <param name="orders">The list of orders to map.</param>
    /// <returns>A list of mapped <see cref="OrderDto"/> objects.</returns>
    private List<OrderDto> ProjectToOrderDto(List<Order> orders)
    {
        List<OrderDto> result = new();
        foreach (var order in orders)
        {
            var orderDto = new OrderDto(
                Id: order.Id!.Value,
                CustomerId: order.CustomerId.Value,
                OrderName: order.OrderName.Value,
                ShippingAddress: new AddressDto(
                    order.ShippingAddress.FirstName,
                    order.ShippingAddress.LastName,
                    order.ShippingAddress.EmailAddress!,
                    order.ShippingAddress.AddressLine,
                    order.ShippingAddress.Country,
                    order.ShippingAddress.State,
                    order.ShippingAddress.ZipCode),
                BillingAddress: new AddressDto(
                    order.BillingAddress.FirstName,
                    order.BillingAddress.LastName,
                    order.BillingAddress.EmailAddress!,
                    order.BillingAddress.AddressLine,
                    order.BillingAddress.Country,
                    order.BillingAddress.State,
                    order.BillingAddress.ZipCode),
                Payment: new PaymentDto(
                    order.Payment.CardName!,
                    order.Payment.CardNumber,
                    order.Payment.Expiration,
                    order.Payment.CVV,
                    order.Payment.PaymentMethod),
                Status: order.Status,
                OrderItems: order.OrderItems.Select(oi => new OrderItemDto(
                    oi.OrderId.Value,
                    oi.ProductId.Value,
                    oi.Quantity,
                    oi.Price)).ToList());

            result.Add(orderDto);
        }

        return result;
    }
}