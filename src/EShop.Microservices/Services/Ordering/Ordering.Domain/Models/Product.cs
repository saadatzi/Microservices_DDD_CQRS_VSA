// <fileheader>
//     <copyright file="Product.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Domain.Models;

/// <summary>
/// Represents a product with a name and price.
/// </summary>
public class Product : Entity<ProductId>
{
    /// <summary>
    /// Prevents a default instance of the <see cref="Product"/> class from being created.
    /// </summary>
    private Product()
    {
    }

    /// <summary>
    /// Gets the name of the product.
    /// </summary>
    public string Name { get; private set; } = default!;

    /// <summary>
    /// Gets the price of the product.
    /// </summary>
    public decimal Price { get; private set; } = default!;

    /// <summary>
    /// Creates a new <see cref="Product"/> instance with the specified ID, name, and price.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <param name="name">The name of the product.</param>
    /// <param name="price">The price of the product.</param>
    /// <returns>A new instance of the <see cref="Product"/> class.</returns>
    /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null or whitespace.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="price"/> is zero or negative.</exception>
    public static Product Create(ProductId id, string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product = new Product
        {
            Id = id,
            Name = name,
            Price = price,
        };

        return product;
    }
}