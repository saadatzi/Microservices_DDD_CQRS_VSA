// <fileheader>
//     <copyright file="Extensions.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
//     <summary>
//         Defines extension methods for the application, specifically for running database migrations
//         at application startup for the Discount gRPC microservice.
//     </summary>
// </fileheader>

namespace Discount.Grpc.Data;

/// <summary>
/// Provides extension methods for application setup.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Ensures that the database migrations are applied at startup.
    /// This method creates a scope, retrieves the DiscountContext, and applies pending migrations.
    /// </summary>
    /// <param name="app">The IApplicationBuilder instance.</param>
    /// <returns>The IApplicationBuilder instance for method chaining.</returns>
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();

        // Apply any pending migrations for the DiscountContext
        dbContext.Database.Migrate();

        return app;
    }
}
