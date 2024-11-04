// <fileheader>
//     <copyright file="Extensions.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

using System.Reflection;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Messaging.MassTransit;

/// <summary>
/// Provides extension methods for configuring message brokers using MassTransit.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Configures the message broker for the service, using MassTransit and RabbitMQ.
    /// </summary>
    /// <param name="services">The IServiceCollection to which the message broker configuration is added.</param>
    /// <param name="configuration">The application configuration, used for retrieving RabbitMQ settings.</param>
    /// <param name="assembly">The assembly containing consumers to be added (optional).</param>
    /// <returns>The IServiceCollection with the configured message broker.</returns>
    public static IServiceCollection AddMessageBroker(
        this IServiceCollection services,
        IConfiguration configuration,
        Assembly? assembly = null)
    {
        services.AddMassTransit(config =>
        {
            // Configures endpoint names to use kebab-case naming convention
            config.SetKebabCaseEndpointNameFormatter();

            // Adds consumers from the specified assembly, if provided
            if (assembly != null)
            {
                config.AddConsumers(assembly);
            }

            // Configures RabbitMQ as the message transport
            config.UsingRabbitMq((context, configurator) =>
            {
                // Sets the RabbitMQ host with credentials from the configuration
                configurator.Host(new Uri(configuration["MessageBroker:Host"]!), host =>
                {
                    host.Username(configuration["MessageBroker:UserName"]!);
                    host.Password(configuration["MessageBroker:Password"]!);
                });

                // Configures endpoints based on the consumers
                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}