// <fileheader>
//     <copyright file="DiscountContext.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

/// <summary>
/// Represents the database context for the Discount microservice.
/// This context is responsible for interacting with the Coupons table in the database.
/// </summary>
public class DiscountContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DiscountContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The options to be used by the <see cref="DbContext"/>.</param>
    public DiscountContext(DbContextOptions<DiscountContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="Coupon"/> entities.
    /// This property provides access to the Coupons table in the database.
    /// </summary>
    public DbSet<Coupon> Coupons { get; set; } = default!;

    /// <summary>
    /// Configures the model creation, including seeding initial data for the Coupons table.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entities.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed initial data for the Coupons table.
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon
            {
                Id = 1,
                ProductName = "iPhone X",
                Description = "iPhone Discount",
                Amount = 150,
            },
            new Coupon
            {
                Id = 2,
                ProductName = "Samsung 10",
                Description = "Samsung Discount",
                Amount = 100,
            });
    }
}