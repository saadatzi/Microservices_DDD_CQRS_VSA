// <fileheader>
//     <copyright file="IntegrationEvent.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace BuildingBlocks.Messaging.Events;

/// <summary>
/// Represents a base integration event used in the messaging system for distributed communication.
/// This event includes an ID, the time of occurrence, and the event type.
/// </summary>
public record IntegrationEvent
{
    /// <summary>
    /// Gets the unique identifier for the integration event.
    /// A new GUID is generated for each instance.
    /// </summary>
    public Guid Id => Guid.NewGuid();

    /// <summary>
    /// Gets the date and time when the integration event occurred.
    /// This is set to the current date and time.
    /// </summary>
    public DateTime OccurredOn => DateTime.Now;

    /// <summary>
    /// Gets the full assembly-qualified name of the event type.
    /// This helps in identifying the exact type of the event when it is being processed.
    /// </summary>
    public string EventType => GetType().AssemblyQualifiedName!;
}