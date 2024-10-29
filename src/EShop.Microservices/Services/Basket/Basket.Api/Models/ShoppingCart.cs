// <fileheader>
//     <copyright file="ShoppingCart.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Basket.API.Models
{
    /// <summary>
    /// Represents a shopping cart for a user.
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCart"/> class with the specified username.
        /// </summary>
        /// <param name="userName">The username associated with the shopping cart.</param>
        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCart"/> class.
        /// </summary>
        public ShoppingCart()
        {
        }

        /// <summary>
        /// Gets or sets the username associated with the shopping cart.
        /// </summary>
        public string UserName { get; set; } = default!;

        /// <summary>
        /// Gets or sets the collection of items in the shopping cart.
        /// </summary>
        public List<ShoppingCartItem> Items { get; set; } = new();

        /// <summary>
        /// Gets the total price of all items in the shopping cart.
        /// </summary>
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    }
}