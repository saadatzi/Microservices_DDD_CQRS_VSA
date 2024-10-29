// <fileheader>
//     <copyright file="DeleteBasketValidator.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Basket.API.Basket.DeleteBasket;

/// <summary>
/// Validator for the <see cref="DeleteBasketCommand"/>.
/// </summary>
public class DeleteBasketValidator : AbstractValidator<DeleteBasketCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteBasketValidator"/> class.
    /// </summary>
    public DeleteBasketValidator()
    {
        // Validation rule to ensure the username is not empty
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("UserName is required");
    }
}