// <fileheader>
//     <copyright file="UpdateOrderCommandValidator.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Orders.Commands.UpdateOrder;

/// <summary>
/// Validator for the <see cref="UpdateOrderCommand"/> command.
/// Defines validation rules for updating an order.
/// </summary>
public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateOrderCommandValidator"/> class.
    /// Defines validation rules for the fields in <see cref="UpdateOrderCommand"/>.
    /// </summary>
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Order.Id)
            .NotEmpty()
            .WithMessage("Id is required");

        RuleFor(x => x.Order.OrderName)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Order.CustomerId)
            .NotNull()
            .WithMessage("CustomerId is required");
    }
}