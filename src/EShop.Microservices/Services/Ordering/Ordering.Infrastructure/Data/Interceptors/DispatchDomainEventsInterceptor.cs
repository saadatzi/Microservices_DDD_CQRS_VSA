// <fileheader>
//     <copyright file="DispatchDomainEventsInterceptor.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Infrastructure.Data.Interceptors;

/// <summary>
/// Interceptor to dispatch domain events during the SaveChanges operation in EF Core.
/// This class triggers the domain events after saving changes to ensure consistency across aggregates.
/// </summary>
public class DispatchDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="DispatchDomainEventsInterceptor"/> class.
    /// </summary>
    /// <param name="mediator">Instance of <see cref="IMediator"/> used to publish domain events.</param>
    public DispatchDomainEventsInterceptor(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <inheritdoc />
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    /// <inheritdoc />
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await DispatchDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    /// <summary>
    /// Dispatches domain events by iterating through aggregates with events and publishing them via Mediator.
    /// </summary>
    /// <param name="context">Current <see cref="DbContext"/> containing the tracked entities.</param>
    private async Task DispatchDomainEvents(DbContext? context)
    {
        if (context == null)
        {
            return;
        }

        // Retrieve all aggregates with domain events
        var aggregates = context.ChangeTracker
                                .Entries<IAggregate>()
                                .Where(a => a.Entity.DomainEvents.Any())
                                .Select(a => a.Entity);

        // Collect all domain events across aggregates
        var domainEvents = aggregates.SelectMany(a => a.DomainEvents).ToList();

        // Clear domain events after collecting them
        aggregates.ToList().ForEach(a => a.ClearDomainEvents());

        // Publish each domain event
        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent);
        }
    }
}