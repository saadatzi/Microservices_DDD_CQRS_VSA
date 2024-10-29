// <fileheader>
//     <copyright file="BasketNotFoundException.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Exceptions;

/// <summary>
/// Exception thrown when a basket is not found.
/// Inherits from <see cref="NotFoundException"/>.
/// </summary>
public class BasketNotFoundException : NotFoundException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BasketNotFoundException"/> class.
    /// </summary>
    /// <param name="userName">The username associated with the basket that was not found.</param>
    public BasketNotFoundException(string userName)
        : base("Basket", userName)
    {
    }
}