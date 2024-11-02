// <fileheader>
//     <copyright file="CreateOrderCommand.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
// File: CreateOrderCommand.cs
namespace Ordering.Application.Orders.Commands.CreateOrder;

/// <summary>
/// Command to create an order with validation and response handling.
/// </summary>
public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;

/// <summary>
/// Result returned after creating an order, containing the new order's ID.
/// </summary>
public record CreateOrderResult(Guid Id);