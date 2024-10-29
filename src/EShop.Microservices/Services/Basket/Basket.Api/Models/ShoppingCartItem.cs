// <fileheader>
//     <copyright file="ShoppingCartItem.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Models;

/// <summary>
/// Represents an item in the shopping cart.
/// </summary>
public class ShoppingCartItem
{
    /// <summary>
    /// Gets or sets the quantity of the item in the cart.
    /// </summary>
    public int Quantity { get; set; } = default!;

    /// <summary>
    /// Gets or sets the color of the product.
    /// </summary>
    public string Color { get; set; } = default!;

    /// <summary>
    /// Gets or sets the price of the item.
    /// </summary>
    public decimal Price { get; set; } = default!;

    /// <summary>
    /// Gets or sets the unique identifier of the product associated with the item.
    /// </summary>
    public Guid ProductId { get; set; } = default!;

    /// <summary>
    /// Gets or sets the name of the product associated with the item.
    /// </summary>
    public string ProductName { get; set; } = default!;
}