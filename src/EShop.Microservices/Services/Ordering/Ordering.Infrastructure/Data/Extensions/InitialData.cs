// <fileheader>
//     <copyright file="InitialData.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Infrastructure.Data.Extensions;

/// <summary>
/// Contains initial data to seed the database with.
/// </summary>
internal class InitialData
{
    /// <summary>
    /// Gets the initial list of customers.
    /// </summary>
    public static IEnumerable<Customer> Customers => new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("aad5f9d2-bb2e-4f67-9b1a-7b7aef4c3e7f")), "alice", "alice@example.com"),
        Customer.Create(CustomerId.Of(new Guid("c2b6a812-5c4d-4e8d-88f5-dfb769b0a1f3")), "bob", "bob@example.com"),
    };

    /// <summary>
    /// Gets the initial list of products.
    /// </summary>
    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("d5a6f9d3-7a8e-41d3-8c95-3e4f5d6e7892")), "Google Pixel 6", 600),
        Product.Create(ProductId.Of(new Guid("ec5d6b2a-b0a2-4e1d-a786-4f2a3b5d9e72")), "OnePlus 9", 550),
        Product.Create(ProductId.Of(new Guid("f6b7d2a1-c8e4-49c5-b9a1-6b7d4a2e7b8f")), "MacBook Air", 1000),
        Product.Create(ProductId.Of(new Guid("b7c8d3a2-f7e5-49d4-9c5e-5d6a4e7c8d7f")), "Dell XPS 13", 950),
    };

    /// <summary>
    /// Gets the initial list of orders.
    /// </summary>
    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            // Define customer addresses
            var address1 = Address.Of("alice", "smith", "alice@example.com", "123 Maple St", "USA", "New York", "10001");
            var address2 = Address.Of("bob", "johnson", "bob@example.com", "456 Oak St", "USA", "Los Angeles", "90001");

            // Define payment information
            var payment1 = Payment.Of("alice", "4111111111111111", "01/25", "123", 1);
            var payment2 = Payment.Of("bob", "4222222222222222", "02/26", "456", 2);

            // Create orders with products and quantities
            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("aad5f9d2-bb2e-4f67-9b1a-7b7aef4c3e7f")),
                OrderName.Of("ORD_1"),
                address1,
                address1,
                payment1);

            order1.Add(ProductId.Of(new Guid("d5a6f9d3-7a8e-41d3-8c95-3e4f5d6e7892")), 2, 600);
            order1.Add(ProductId.Of(new Guid("ec5d6b2a-b0a2-4e1d-a786-4f2a3b5d9e72")), 1, 550);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("c2b6a812-5c4d-4e8d-88f5-dfb769b0a1f3")),
                OrderName.Of("ORD_2"),
                address2,
                address2,
                payment2);

            order2.Add(ProductId.Of(new Guid("f6b7d2a1-c8e4-49c5-b9a1-6b7d4a2e7b8f")), 1, 1000);
            order2.Add(ProductId.Of(new Guid("b7c8d3a2-f7e5-49d4-9c5e-5d6a4e7c8d7f")), 1, 950);

            return new List<Order> { order1, order2 };
        }
    }
}