// <fileheader>
//     <copyright file="IEntity.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Domain.Abstractions;

/// <summary>
/// Generic interface IEntity representing an entity with an identifier.
/// </summary>
/// <typeparam name="T">The type of the identifier.</typeparam>
public interface IEntity<T> : IEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    T? Id { get; set; }
}

/// <summary>
/// Interface IEntity representing common entity properties for auditing purposes.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the creator.
    /// </summary>
    string? CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last modified.
    /// </summary>
    DateTime? LastModified { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the last modifier.
    /// </summary>
    string? LastModifiedBy { get; set; }
}