// <fileheader>
//     <copyright file="ApplicationDbContext.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Infrastructure.Data;

/// <summary>
/// Represents the database context for the Ordering service, derived from DbContext.
/// This context is used to configure the EF Core settings and provide DbSets for the domain models.
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets / sets the Customers DbSet, which represents the collection of all <see cref="Customer"/> entities in the context.
    /// </summary>
    public DbSet<Customer> Customers => Set<Customer>();

    /// <summary>
    /// Gets / sets the Products DbSet, which represents the collection of all <see cref="Product"/> entities in the context.
    /// </summary>
    public DbSet<Product> Products => Set<Product>();

    /// <summary>
    /// Gets / sets the Orders DbSet, which represents the collection of all <see cref="Order"/> entities in the context.
    /// </summary>
    public DbSet<Order> Orders => Set<Order>();

    /// <summary>
    /// Gets / sets the OrderItems DbSet, which represents the collection of all <see cref="OrderItem"/> entities in the context.
    /// </summary>
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    /// <summary>
    /// Configures the model using the ModelBuilder, applying all configurations from the executing assembly.
    /// </summary>
    /// <param name="builder">The ModelBuilder instance used to configure the model.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}