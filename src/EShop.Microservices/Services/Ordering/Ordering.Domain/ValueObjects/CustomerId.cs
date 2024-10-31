// <fileheader>
//     <copyright file="CustomerId.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Domain.ValueObjects;

/// <summary>
/// Represents a unique identifier for a customer.
/// </summary>
public record CustomerId
{
    /// <summary>
    /// Prevents a default instance of the <see cref="CustomerId"/> class from being created.
    /// </summary>
    private CustomerId(Guid value) => Value = value;

    /// <summary>
    /// Gets the GUID value of the customer ID.
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Creates a new <see cref="CustomerId"/> instance with the specified GUID value.
    /// </summary>
    /// <param name="value">The GUID value for the customer ID.</param>
    /// <returns>A new instance of <see cref="CustomerId"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    /// <exception cref="DomainException">Thrown when <paramref name="value"/> is an empty GUID.</exception>
    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
        {
            throw new DomainException("CustomerId cannot be empty.");
        }

        return new CustomerId(value);
    }
}