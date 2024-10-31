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

    /// <summary>
    /// Creates a new <see cref="Order"/> instance with the specified details.
    /// </summary>
    /// <param name="id">The unique identifier for the order.</param>
    /// <param name="customerId">The customer ID associated with the order.</param>
    /// <param name="orderName">The name of the order.</param>
    /// <param name="shippingAddress">The shipping address for the order.</param>
    /// <param name="billingAddress">The billing address for the order.</param>
    /// <param name="payment">The payment information for the order.</param>
    /// <returns>A new <see cref="Order"/> instance with an associated domain event for order creation.</returns>
    public static Order Create(
        OrderId id,
        CustomerId customerId,
        OrderName orderName,
        Address shippingAddress,
        Address billingAddress,
        Payment payment)
    {
        var order = new Order
        {
            Id = id,
            CustomerId = customerId,
            OrderName = orderName,
            ShippingAddress = shippingAddress,
            BillingAddress = billingAddress,
            Payment = payment,
            Status = OrderStatus.Pending,
        };

        // Add a domain event indicating that the order has been created.
        order.AddDomainEvent(new OrderCreatedEvent(order));

        return order;
    }

    /// <summary>
    /// Updates the order details and raises an <see cref="OrderUpdatedEvent"/>.
    /// </summary>
    /// <param name="orderName">The new name of the order.</param>
    /// <param name="shippingAddress">The new shipping address for the order.</param>
    /// <param name="billingAddress">The new billing address for the order.</param>
    /// <param name="payment">The new payment details for the order.</param>
    /// <param name="status">The new status of the order.</param>
    public void Update(
        OrderName orderName,
        Address shippingAddress,
        Address billingAddress,
        Payment payment,
        OrderStatus status)
    {
        OrderName = orderName;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
        Payment = payment;
        Status = status;

        // Add a domain event indicating that the order has been updated.
        AddDomainEvent(new OrderUpdatedEvent(this));
    }

    /// <summary>
    /// Adds an item to the order.
    /// </summary>
    /// <param name="productId">The ID of the product to add.</param>
    /// <param name="quantity">The quantity of the product to add.</param>
    /// <param name="price">The price of the product.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="quantity"/> or <paramref name="price"/> is less than or equal to zero.
    /// </exception>
    public void Add(ProductId productId, int quantity, decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var orderItem = new OrderItem(Id!, productId, quantity, price);
        _orderItems.Add(orderItem);
    }

    /// <summary>
    /// Removes an item from the order based on the product ID.
    /// </summary>
    /// <param name="productId">The ID of the product to remove.</param>
    public void Remove(ProductId productId)
    {
        var orderItem = _orderItems.FirstOrDefault(x => x.ProductId == productId);
        if (orderItem is not null)
        {
            _orderItems.Remove(orderItem);
        }
    }
}