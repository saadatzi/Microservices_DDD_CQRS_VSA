// <fileheader>
//     <copyright file="CreateOrderCommandValidator.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Orders.Commands.CreateOrder;

/// <summary>
/// Validator for CreateOrderCommand to ensure required fields are populated.
/// </summary>
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateOrderCommandValidator"/> class.
    /// Defines validation rules for the <see cref="CreateOrderCommand"/>.
    /// </summary>
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Order.OrderName)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Order.CustomerId)
            .NotNull()
            .WithMessage("CustomerId is required");

        RuleFor(x => x.Order.OrderItems)
            .NotEmpty()
            .WithMessage("OrderItems should not be empty");
    }
}
