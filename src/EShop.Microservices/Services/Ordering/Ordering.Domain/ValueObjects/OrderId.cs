// <fileheader>
//     <copyright file="OrderId.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Domain.ValueObjects;

/// <summary>
/// Represents a unique identifier for an order in the system.
/// </summary>
public record OrderId
{
    /// <summary>
    /// Prevents a default instance of the <see cref="OrderId"/> class from being created.
    /// </summary>
    /// <param name="value">The GUID value of the order ID.</param>
    private OrderId(Guid value) => Value = value;

    /// <summary>
    /// Gets the GUID value of the order ID.
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Creates a new <see cref="OrderId"/> instance with the specified GUID value.
    /// </summary>
    /// <param name="value">The GUID value to create the <see cref="OrderId"/>.</param>
    /// <returns>A new instance of <see cref="OrderId"/> with the specified value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided GUID value is null.</exception>
    /// <exception cref="DomainException">Thrown when the provided GUID value is empty.</exception>
    public static OrderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
        {
            throw new DomainException("OrderId cannot be empty.");
        }

        return new OrderId(value);
    }
}