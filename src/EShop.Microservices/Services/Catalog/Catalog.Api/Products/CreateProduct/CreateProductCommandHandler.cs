// <fileheader>
//     <copyright file="CreateProductCommandHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Catalog.Api.Products.CreateProduct;

/// <summary>
/// Handles the creation of a product.
/// </summary>
internal class CreateProductCommandHandler(
    IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    /// <summary>
    /// Handles the creation of a product based on the provided command.
    /// </summary>
    /// <param name="command">The create product command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation and returns the created product result.</returns>
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Business logic to create a product
        // Create a new product entity from command object
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };

        // save to database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        // return new CreateproductResult(newProduct.Id);
        return new CreateProductResult(product.Id);
    }
}

/// <summary>
/// Represents a command for creating a product.
/// </summary>
public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price) : ICommand<CreateProductResult>;

/// <summary>
/// Represents the result of creating a product.
/// </summary>
public record CreateProductResult(Guid Id);