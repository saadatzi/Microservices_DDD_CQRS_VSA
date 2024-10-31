// <fileheader>
//     <copyright file="OrderName.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Domain.ValueObjects;

/// <summary>
/// Represents the name of an order in the system.
/// </summary>
public record OrderName
{
    /// <summary>
    /// The default length for the order name.
    /// </summary>
    private const int DefaultLength = 5;

    /// <summary>
    /// Prevents a default instance of the <see cref="OrderName"/> class from being created.
    /// </summary>
    /// <param name="value">The name value of the order.</param>
    private OrderName(string value) => Value = value;

    /// <summary>
    /// Gets the value of the order name.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Creates a new <see cref="OrderName"/> instance with the specified name value.
    /// </summary>
    /// <param name="value">The name to assign to the order.</param>
    /// <returns>A new instance of <see cref="OrderName"/> with the specified value.</returns>
    /// <exception cref="ArgumentException">Thrown when the provided value is null or whitespace.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the length of the provided value does not match the default length.</exception>
    public static OrderName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);

        return new OrderName(value);
    }
}