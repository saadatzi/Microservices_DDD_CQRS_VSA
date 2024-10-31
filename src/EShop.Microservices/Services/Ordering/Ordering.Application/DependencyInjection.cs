// <fileheader>
//     <copyright file="DependencyInjection.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application;

/// <summary>
/// Provides extension methods for adding application layer services to the IServiceCollection.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to register all application services to the IServiceCollection.
    /// This includes services like MediatR or other CQRS-related configurations.
    /// </summary>
    /// <param name="services">The IServiceCollection to which services are added.</param>
    /// <returns>The updated IServiceCollection with registered application services.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Uncomment the following lines to add MediatR and automatically register handlers
        // from the current assembly, typically used in CQRS implementations.

        // services.AddMediatR(cfg =>
        // {
        //     cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        // });
        return services;
    }
}