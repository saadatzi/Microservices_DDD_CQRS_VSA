// <fileheader>
//     <copyright file="OrderItem.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Domain.Models;

/// <summary>
/// Represents an item within an order, containing product information, quantity, and price.
/// </summary>
public class OrderItem : Entity<OrderItemId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderItem"/> class.
    /// </summary>
    /// <param name="orderId">The unique identifier for the order.</param>
    /// <param name="productId">The unique identifier for the product.</param>
    /// <param name="quantity">The quantity of the product ordered.</param>
    /// <param name="price">The price of the product.</param>
    internal OrderItem(OrderId orderId, ProductId productId, int quantity, decimal price)
    {
        Id = OrderItemId.Of(Guid.NewGuid());
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    /// <summary>
    /// Gets the unique identifier of the order to which this item belongs.
    /// </summary>
    public OrderId OrderId { get; private set; } = default!;

    /// <summary>
    /// Gets the unique identifier of the product associated with this order item.
    /// </summary>
    public ProductId ProductId { get; private set; } = default!;

    /// <summary>
    /// Gets the quantity of the product in this order item.
    /// </summary>
    public int Quantity { get; private set; } = default!;

    /// <summary>
    /// Gets the price of the product in this order item.
    /// </summary>
    public decimal Price { get; private set; } = default!;
}