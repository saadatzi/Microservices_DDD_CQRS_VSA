// <fileheader>
//     <copyright file="Customer.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Domain.Models;

/// <summary>
/// Represents a customer entity with unique identifier, name, and email.
/// </summary>
public class Customer : Entity<CustomerId>
{
    /// <summary>
    /// Gets the name of the customer.
    /// </summary>
    public string Name { get; private set; } = default!;

    /// <summary>
    /// Gets the email of the customer.
    /// </summary>
    public string Email { get; private set; } = default!;

    /// <summary>
    /// Creates a new instance of the <see cref="Customer"/> class with the specified id, name, and email.
    /// </summary>
    /// <param name="id">The unique identifier for the customer.</param>
    /// <param name="name">The name of the customer.</param>
    /// <param name="email">The email of the customer.</param>
    /// <returns>A new instance of the <see cref="Customer"/> class.</returns>
    /// <exception cref="ArgumentException">Thrown when the name or email is null or whitespace.</exception>
    public static Customer Create(CustomerId id, string name, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        var customer = new Customer
        {
            Id = id,
            Name = name,
            Email = email,
        };

        return customer;
    }
}