// <fileheader>
//     <copyright file="DeleteProductCommandValidator.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Catalog.Api.Products.DeleteProduct;

/// <summary>
/// Validates the properties of a <see cref="DeleteProductCommand"/> to ensure they meet the required conditions.
/// </summary>
public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteProductCommandValidator"/> class.
    /// Defines validation rules for the <see cref="DeleteProductCommand"/> properties.
    /// </summary>
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is required");
    }
}