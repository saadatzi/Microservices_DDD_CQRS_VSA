// <fileheader>
//     <copyright file="OrderItemId.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Domain.ValueObjects;

/// <summary>
/// Represents a unique identifier for an order item in the system.
/// </summary>
public record OrderItemId
{
    /// <summary>
    /// Prevents a default instance of the <see cref="OrderItemId"/> class from being created.
    /// </summary>
    /// <param name="value">The GUID value of the order item ID.</param>
    private OrderItemId(Guid value) => Value = value;

    /// <summary>
    /// Gets the GUID value of the order item ID.
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Creates a new <see cref="OrderItemId"/> instance with the specified GUID value.
    /// </summary>
    /// <param name="value">The GUID value to create the <see cref="OrderItemId"/>.</param>
    /// <returns>A new instance of <see cref="OrderItemId"/> with the specified value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided GUID value is null.</exception>
    /// <exception cref="DomainException">Thrown when the provided GUID value is empty.</exception>
    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
        {
            throw new DomainException("OrderItemId cannot be empty.");
        }

        return new OrderItemId(value);
    }
}