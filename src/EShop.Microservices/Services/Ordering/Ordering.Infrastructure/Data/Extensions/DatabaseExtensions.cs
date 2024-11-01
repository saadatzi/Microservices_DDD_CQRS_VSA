// <fileheader>
//     <copyright file="DatabaseExtensions.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Infrastructure.Data.Extensions;

using Microsoft.AspNetCore.Builder;

/// <summary>
/// Provides extension methods for initializing and seeding the database within a web application.
/// </summary>
public static class DatabaseExtensions
{
    /// <summary>
    /// Initializes the database by applying any pending migrations and seeding initial data.
    /// This extension method is designed for use within the startup pipeline of a web application.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance used to access application services.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        // Create a scope to obtain services from the dependency injection container.
        using var scope = app.Services.CreateScope();

        // Resolve the ApplicationDbContext service from the scope's service provider.
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // Apply any pending migrations to the database.
        await context.Database.MigrateAsync().ConfigureAwait(false);

        // Seed the database with initial data.
        await SeedAsync(context);
    }

    /// <summary>
    /// Seeds initial data into the database.
    /// </summary>
    /// <param name="context">The <see cref="ApplicationDbContext"/> to interact with the database.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    private static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedCustomerAsync(context);
        await SeedProductAsync(context);
        await SeedOrdersWithItemsAsync(context);
    }

    /// <summary>
    /// Seeds customer data if none exists in the database.
    /// </summary>
    /// <param name="context">The <see cref="ApplicationDbContext"/> to interact with the database.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    private static async Task SeedCustomerAsync(ApplicationDbContext context)
    {
        if (!await context.Customers.AnyAsync())
        {
            await context.Customers.AddRangeAsync(InitialData.Customers);
            await context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Seeds product data if none exists in the database.
    /// </summary>
    /// <param name="context">The <see cref="ApplicationDbContext"/> to interact with the database.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    private static async Task SeedProductAsync(ApplicationDbContext context)
    {
        if (!await context.Products.AnyAsync())
        {
            await context.Products.AddRangeAsync(InitialData.Products);
            await context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Seeds order data if none exists in the database.
    /// </summary>
    /// <param name="context">The <see cref="ApplicationDbContext"/> to interact with the database.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    private static async Task SeedOrdersWithItemsAsync(ApplicationDbContext context)
    {
        if (!await context.Orders.AnyAsync())
        {
            await context.Orders.AddRangeAsync(InitialData.OrdersWithItems);
            await context.SaveChangesAsync();
        }
    }
}