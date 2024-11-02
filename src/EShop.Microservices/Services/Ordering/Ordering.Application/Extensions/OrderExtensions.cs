// <fileheader>
//     <copyright file="OrderExtensions.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Application.Extensions;

/// <summary>
/// Extension methods for <see cref="Order"/> objects.
/// </summary>
public static class OrderExtensions
{
    /// <summary>
    /// Converts an <see cref="IEnumerable{Order}"/> to an <see cref="IEnumerable{OrderDto}"/>.
    /// </summary>
    /// <param name="orders">The list of orders to convert.</param>
    /// <returns>An <see cref="IEnumerable{OrderDto}"/> containing the converted orders.</returns>
    public static IEnumerable<OrderDto> ToOrderDtoList(this IEnumerable<Order> orders)
    {
        return orders.Select(order => new OrderDto(
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
                oi.Price)).ToList()));
    }
}