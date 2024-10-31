// <fileheader>
//     <copyright file="ProductId.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Domain.ValueObjects;

/// <summary>
/// Represents a unique identifier for a product in the system.
/// </summary>
public record ProductId
{
    /// <summary>
    /// Prevents a default instance of the <see cref="ProductId"/> class from being created.
    /// </summary>
    /// <param name="value">The GUID value of the product ID.</param>
    private ProductId(Guid value) => Value = value;

    /// <summary>
    /// Gets the GUID value of the product ID.
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Creates a new <see cref="ProductId"/> instance with the specified GUID value.
    /// </summary>
    /// <param name="value">The GUID value to create the <see cref="ProductId"/>.</param>
    /// <returns>A new instance of <see cref="ProductId"/> with the specified value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided GUID value is null.</exception>
    /// <exception cref="DomainException">Thrown when the provided GUID value is empty.</exception>
    public static ProductId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
        {
            throw new DomainException("ProductId cannot be empty.");
        }

        return new ProductId(value);
    }
}