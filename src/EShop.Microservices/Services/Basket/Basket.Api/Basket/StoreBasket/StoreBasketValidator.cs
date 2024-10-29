// <fileheader>
//     <copyright file="StoreBasketValidator.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Basket.StoreBasket;

/// <summary>
/// Validates the <see cref="StoreBasketCommand"/> to ensure that it contains valid data.
/// </summary>
public class StoreBasketValidator : AbstractValidator<StoreBasketCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StoreBasketValidator"/> class.
    /// </summary>
    public StoreBasketValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be null.");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required.");
    }
}