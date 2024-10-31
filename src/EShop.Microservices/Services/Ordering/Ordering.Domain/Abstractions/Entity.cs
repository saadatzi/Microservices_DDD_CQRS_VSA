// <fileheader>
//     <copyright file="Entity.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Domain.Abstractions;

/// <summary>
/// Abstract class Entity representing an entity with an identifier and audit properties.
/// </summary>
/// <typeparam name="T">The type of the identifier.</typeparam>
public abstract class Entity<T> : IEntity<T>
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    public T? Id { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the creator.
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last modified.
    /// </summary>
    public DateTime? LastModified { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the last modifier.
    /// </summary>
    public string? LastModifiedBy { get; set; }
}