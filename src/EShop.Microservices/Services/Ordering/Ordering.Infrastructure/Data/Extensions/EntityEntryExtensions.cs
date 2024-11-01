// <fileheader>
//     <copyright file="EntityEntryExtensions.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Infrastructure.Data.Extensions;

/// <summary>
/// Extension method for EntityEntry to check if owned entities have changed.
/// </summary>
public static class EntityEntryExtensions
{
    /// <summary>
    /// Checks if any owned entities have changed by inspecting the references within the EntityEntry.
    /// </summary>
    /// <param name="entry">Entity entry to check for changes in owned entities.</param>
    /// <returns>True if any owned entities have been modified, otherwise false.</returns>
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}