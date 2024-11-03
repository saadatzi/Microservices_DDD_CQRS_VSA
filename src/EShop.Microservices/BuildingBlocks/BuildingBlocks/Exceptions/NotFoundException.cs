// <fileheader>
//     <copyright file="NotFoundException.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace BuildingBlocks.Exceptions;

/// <summary>
/// Represents a not found exception.
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class with a custom message.
    /// </summary>
    /// <param name="message">The custom message for the exception.</param>
    public NotFoundException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class with the entity name and key.
    /// </summary>
    /// <param name="name">The name of the entity that was not found.</param>
    /// <param name="key">The key of the entity that was not found.</param>
    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
}