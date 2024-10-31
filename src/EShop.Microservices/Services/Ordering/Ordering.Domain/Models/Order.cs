// <fileheader>
//     <copyright file="Order.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Domain.Models;

/// <summary>
/// Represents an order in the system with customer information, shipping and billing addresses, payment details,
/// order status, and a calculated total price.
/// </summary>
public class Order : Aggregate<OrderId>
{
    /// <summary>
    /// Collection of items within the order.
    /// </summary>
    private readonly List<OrderItem> _orderItems = new();

    /// <summary>
    /// Prevents a default instance of the <see cref="Order"/> class from being created.
    /// </summary>
    private Order()
    {
    }

    /// <summary>
    /// Gets a read-only collection of items in the order.
    /// </summary>
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

    /// <summary>
    /// Gets the unique identifier of the customer who placed the order.
    /// </summary>
    public CustomerId CustomerId { get; private set; } = default!;

    /// <summary>
    /// Gets the name associated with the order.
    /// </summary>
    public OrderName OrderName { get; private set; } = default!;

    /// <summary>
    /// Gets the shipping address for the order.
    /// </summary>
    public Address ShippingAddress { get; private set; } = default!;

    /// <summary>
    /// Gets the billing address for the order.
    /// </summary>
    public Address BillingAddress { get; private set; } = default!;

    /// <summary>
    /// Gets the payment details for the order.
    /// </summary>
    public Payment Payment { get; private set; } = default!;

    /// <summary>
    /// Gets / sets the status of the order, initialized to pending.
    /// </summary>
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;

    /// <summary>
    /// Gets the total price of the order, calculated as the sum of the price times quantity for each item in the order.
    /// </summary>
    public decimal TotalPrice
    {
        get => OrderItems.Sum(x => x.Price * x.Quantity);
        private set { }
    }
}