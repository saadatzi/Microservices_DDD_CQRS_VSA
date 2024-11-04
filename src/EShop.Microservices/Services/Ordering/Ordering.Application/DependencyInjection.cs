// <fileheader>
//     <copyright file="DependencyInjection.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

using System.Reflection;
using BuildingBlocks.Behaviors;
using Microsoft.Extensions.Configuration;
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
    /// <param name="configuration">The IConfiguration to fetch appsettings.json values.</param>
    /// <returns>The updated IServiceCollection with registered application services.</returns>
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());
        return services;
    }
}