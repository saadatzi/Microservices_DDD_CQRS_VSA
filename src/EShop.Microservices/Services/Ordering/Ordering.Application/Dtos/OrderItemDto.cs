// <fileheader>
//     <copyright file="OrderItemDto.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Dtos;

/// <summary>
/// Represents an order item data transfer object (DTO) containing details of a single item in an order.
/// </summary>
/// <param name="OrderId">The unique identifier for the order containing this item.</param>
/// <param name="ProductId">The unique identifier of the product.</param>
/// <param name="Quantity">The quantity of the product in the order.</param>
/// <param name="Price">The price of the product.</param>
public record OrderItemDto(
    Guid OrderId,
    Guid ProductId,
    int Quantity,
    decimal Price);