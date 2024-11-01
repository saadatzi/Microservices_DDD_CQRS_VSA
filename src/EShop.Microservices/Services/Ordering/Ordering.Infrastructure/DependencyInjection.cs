// <fileheader>
//     <copyright file="DependencyInjection.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Infrastructure;

/// <summary>
/// Provides extension methods for adding infrastructure layer services to the IServiceCollection.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to register all infrastructure services to the IServiceCollection.
    /// This typically includes configurations for database contexts and related services.
    /// </summary>
    /// <param name="services">The IServiceCollection to which services are added.</param>
    /// <param name="configuration">The application's configuration properties.</param>
    /// <returns>The updated IServiceCollection with registered infrastructure services.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Retrieve the connection string from the configuration settings
        var connectionString = configuration.GetConnectionString("Database");

        //// Add services to the container, like DbContext for EF Core.
        //// Uncomment the following lines when setting up Entity Framework Core:

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        //// Register the ApplicationDbContext with a scoped lifetime for DI.
        //// services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}
