// <fileheader>
//     <copyright file="AuditableEntityInterceptor.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Infrastructure.Data.Interceptors;

/// <summary>
/// An interceptor that can be used to automatically audit changes to entities in the database.
/// </summary>
public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    /// <summary>
    /// Overrides the SavingChanges method to inject auditing logic.
    /// </summary>
    /// <param name="eventData">Event data containing DbContext for tracking changes.</param>
    /// <param name="result">Interception result for SaveChanges.</param>
    /// <returns>Interception result of SaveChanges operation.</returns>
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    /// <summary>
    /// Overrides the asynchronous SavingChangesAsync method to inject auditing logic.
    /// </summary>
    /// <param name="eventData">Event data containing DbContext for tracking changes.</param>
    /// <param name="result">Interception result for SaveChangesAsync.</param>
    /// <param name="cancellationToken">Cancellation token for asynchronous operation.</param>
    /// <returns>Interception result of the asynchronous SaveChanges operation.</returns>
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    /// <summary>
    /// Updates entity tracking information for audit fields. If the entity is new, it sets CreatedAt and CreatedBy.
    /// If the entity is modified, it sets LastModifiedAt and LastModifiedBy.
    /// </summary>
    /// <param name="context">The database context containing tracked entities.</param>
    public void UpdateEntities(DbContext? context)
    {
        if (context == null)
        {
            return;
        }

        foreach (var entry in context.ChangeTracker.Entries<IEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = "admin";
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
            {
                entry.Entity.LastModifiedBy = "admin";
                entry.Entity.LastModified = DateTime.UtcNow;
            }
        }
    }
}