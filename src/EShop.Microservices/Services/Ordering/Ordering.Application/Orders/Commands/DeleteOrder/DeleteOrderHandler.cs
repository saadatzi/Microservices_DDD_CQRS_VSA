// <fileheader>
//     <copyright file="DeleteOrderHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Orders.Commands.DeleteOrder;

/// <summary>
/// Handler for processing the <see cref="DeleteOrderCommand"/> to delete an order.
/// </summary>
public class DeleteOrderHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    /// <summary>
    /// Handles the deletion of an order.
    /// </summary>
    /// <param name="command">The command containing the order ID to delete.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the delete operation.</returns>
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        // Get Order ID from the command
        var orderId = OrderId.Of(command.OrderId);

        // Find the order in the database
        var order = await dbContext.Orders
            .FindAsync(new object[] { orderId }, cancellationToken: cancellationToken);

        // If order is not found, throw OrderNotFoundException
        if (order is null)
        {
            throw new OrderNotFoundException(command.OrderId);
        }

        // Remove order from database
        dbContext.Orders.Remove(order);

        // Save changes to database
        await dbContext.SaveChangesAsync(cancellationToken);

        // Return result indicating successful deletion
        return new DeleteOrderResult(true);
    }
}