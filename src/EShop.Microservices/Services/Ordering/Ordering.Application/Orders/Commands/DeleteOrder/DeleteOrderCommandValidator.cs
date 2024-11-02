// <fileheader>
//     <copyright file="DeleteOrderCommandValidator.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Orders.Commands.DeleteOrder;

/// <summary>
/// Validator for the <see cref="DeleteOrderCommand"/> to ensure required fields are present.
/// </summary>
public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteOrderCommandValidator"/> class.
    /// Defines validation rules for deleting an order.
    /// </summary>
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty()
            .WithMessage("OrderId is required");
    }
}