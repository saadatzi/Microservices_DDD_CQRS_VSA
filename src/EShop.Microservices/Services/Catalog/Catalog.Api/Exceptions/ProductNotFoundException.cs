// <fileheader>
//     <copyright file="ProductNotFoundException.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
using BuildingBlocks.Exceptions;

namespace Catalog.Api.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a specified product cannot be found.
/// </summary>
[Serializable]
internal class ProductNotFoundException : NotFoundException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductNotFoundException"/> class with a default error message.
    /// </summary>
    /// <param name="id">The unique identifier of the product that was not found.</param>
    public ProductNotFoundException(Guid id)
        : base("Product", id)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductNotFoundException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public ProductNotFoundException(string? message)
        : base(message ?? "Product not found!")
    {
    }
}