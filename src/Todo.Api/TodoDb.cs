// <fileheader>
//     <copyright file="TodoDb.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Todo.Api;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Represents the database context for the Todo application.
/// </summary>
public class TodoDb : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TodoDb"/> class with the specified options.
    /// </summary>
    /// <param name="options">The options for this context.</param>
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the database set of todo items.
    /// </summary>
    public DbSet<TodoItem> Todos { get; set; }
}