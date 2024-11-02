// <fileheader>
//     <copyright file="OrderNotFoundException.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

using BuildingBlocks.Exceptions;

namespace Ordering.Application.Exceptions;

/// <summary>
/// Exception that is thrown when an order cannot be found.
/// </summary>
public class OrderNotFoundException : NotFoundException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderNotFoundException"/> class with a specified order ID.
    /// </summary>
    /// <param name="id">The ID of the order that could not be found.</param>
    public OrderNotFoundException(Guid id)
        : base("Order", id)
    {
    }
}