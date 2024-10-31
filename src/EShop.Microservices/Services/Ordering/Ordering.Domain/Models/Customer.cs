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
}