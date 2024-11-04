// <fileheader>
//     <copyright file="CheckoutBasketCommandValidator.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Basket.CheckoutBasket;

/// <summary>
/// Validator for the <see cref="CheckoutBasketCommand"/>.
/// Ensures that necessary fields are not null or empty.
/// </summary>
public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CheckoutBasketCommandValidator"/> class.
    /// Sets up validation rules for the command.
    /// </summary>
    public CheckoutBasketCommandValidator()
    {
        // Validate that BasketCheckoutDto is not null
        RuleFor(x => x.BasketCheckoutDto)
            .NotNull()
            .WithMessage("BasketCheckoutDto must not be null.");

        // Validate that the UserName in BasketCheckoutDto is not empty
        RuleFor(x => x.BasketCheckoutDto.UserName)
            .NotEmpty()
            .WithMessage("UserName must not be empty.");
    }
}