// <fileheader>
//     <copyright file="TodoItem.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Todo.Api;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents a todo item.
/// </summary>
public class TodoItem(int id, string name)
{
    /// <summary>
    /// Gets or sets the unique identifier of the todo item.
    /// </summary>
    public int Id { get; set; } = id;

    /// <summary>
    /// Gets or sets the name of the todo item.
    /// </summary>
    [Required]
    public string Name { get; set; } = name ?? throw new ArgumentNullException(nameof(name));

    /// <summary>
    /// Gets or sets a value indicating whether the todo item is complete.
    /// </summary>
    public bool IsComplete { get; set; } = false; // Default value if not provided
}