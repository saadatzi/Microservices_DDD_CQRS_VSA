// <fileheader>
//     <copyright file="IApplicationDbContext.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
using Microsoft.EntityFrameworkCore;

namespace Ordering.Application.Data;

/// <summary>
/// Interface representing the application database context with DbSet properties for managing data entities.
/// </summary>
public interface IApplicationDbContext
{
    /// <summary>
    /// Gets / sets the Customers in the database.
    /// </summary>
    DbSet<Customer> Customers { get; }

    /// <summary>
    /// Gets / sets the Products in the database.
    /// </summary>
    DbSet<Product> Products { get; }

    /// <summary>
    /// Gets / sets the Orders in the database.
    /// </summary>
    DbSet<Order> Orders { get; }

    /// <summary>
    /// Gets / sets the OrderItems in the database.
    /// </summary>
    DbSet<OrderItem> OrderItems { get; }

    /// <summary>
    /// Saves all changes made in this context to the database asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
