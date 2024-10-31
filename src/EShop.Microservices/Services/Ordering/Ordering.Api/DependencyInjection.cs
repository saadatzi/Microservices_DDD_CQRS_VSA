// <fileheader>
//     <copyright file="DependencyInjection.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Api;

/// <summary>
/// Provides extension methods for adding and using API layer services in the IServiceCollection and WebApplication.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers services needed for the API layer.
    /// </summary>
    /// <param name="services">The IServiceCollection to which services are added.</param>
    /// <returns>The updated IServiceCollection with API services registered.</returns>
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        // Uncomment the following line to add Carter services, which allows defining minimal API endpoints.
        // services.AddCarter();
        return services;
    }

    /// <summary>
    /// Configures the WebApplication to use API-specific services, such as routing for Carter endpoints.
    /// </summary>
    /// <param name="app">The WebApplication to be configured.</param>
    /// <returns>The updated WebApplication with API configurations applied.</returns>
    public static WebApplication UseApiServices(this WebApplication app)
    {
        // Uncomment the following line to map Carter endpoints to the application.
        // app.MapCarter();
        return app;
    }
}