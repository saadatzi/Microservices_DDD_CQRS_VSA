// <fileheader>
//     <copyright file="OrderDto.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Dtos;

/// <summary>
/// Represents an order data transfer object (DTO) containing order details.
/// </summary>
/// <param name="Id">The unique identifier for the order.</param>
/// <param name="CustomerId">The unique identifier of the customer who placed the order.</param>
/// <param name="OrderName">The name of the order.</param>
/// <param name="ShippingAddress">The address to which the order will be shipped.</param>
/// <param name="BillingAddress">The billing address associated with the order.</param>
/// <param name="Payment">The payment details for the order.</param>
/// <param name="Status">The current status of the order.</param>
/// <param name="OrderItems">The list of items in the order.</param>
public record OrderDto(
    Guid Id,
    Guid CustomerId,
    string OrderName,
    AddressDto ShippingAddress,
    AddressDto BillingAddress,
    PaymentDto Payment,
    OrderStatus Status,
    List<OrderItemDto> OrderItems);