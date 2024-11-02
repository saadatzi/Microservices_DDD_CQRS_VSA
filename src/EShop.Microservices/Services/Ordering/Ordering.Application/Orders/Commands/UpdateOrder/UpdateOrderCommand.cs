// <fileheader>
//     <copyright file="UpdateOrderCommand.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Orders.Commands.UpdateOrder;

/// <summary>
/// Represents a command to update an existing order.
/// </summary>
/// <param name="Order">The order details to be updated.</param>
public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResult>;

/// <summary>
/// Represents the result of an UpdateOrderCommand.
/// </summary>
/// <param name="IsSuccess">Indicates if the update was successful.</param>
public record UpdateOrderResult(bool IsSuccess);