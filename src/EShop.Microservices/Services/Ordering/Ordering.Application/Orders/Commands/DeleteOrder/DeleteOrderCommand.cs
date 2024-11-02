// <fileheader>
//     <copyright file="DeleteOrderCommand.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Orders.Commands.DeleteOrder;

/// <summary>
/// Command to delete an order by its ID.
/// </summary>
/// <param name="OrderId">The unique identifier of the order to be deleted.</param>
public record DeleteOrderCommand(Guid OrderId) : ICommand<DeleteOrderResult>;

/// <summary>
/// Result of the delete order command.
/// </summary>
/// <param name="IsSuccess">Indicates whether the order deletion was successful.</param>
public record DeleteOrderResult(bool IsSuccess);