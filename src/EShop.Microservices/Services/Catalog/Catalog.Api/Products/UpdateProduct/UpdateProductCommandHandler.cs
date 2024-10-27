// <fileheader>
//     <copyright file="UpdateProductCommandHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Catalog.Api.Products.UpdateProduct;

using Catalog.Api.Exceptions;

/// <summary>
/// Handles the update of a product.
/// </summary>
internal class UpdateProductCommandHandler(
    IDocumentSession session,
    ILogger<UpdateProductCommandHandler> logger)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    /// <summary>
    /// Handles the product update based on the provided command.
    /// </summary>
    /// <param name="command">The update product command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation and returns the updated product result.</returns>
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductCommandHandler.Handle called with {@Command}", command);

        // Update the product entity from command object
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product == null)
        {
            throw new ProductNotFoundException($"Product with Id number of {command.Id} is not found to update.");
        }

        product.Name = command.Name;
        product.Category = command.Category;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;

        // save to database
        session.Update(product);
        try
        {
            await session.SaveChangesAsync(cancellationToken);
            return new UpdateProductResult(true);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error saving changes to the database for product with ID {ProductId}", command.Id);
            return new UpdateProductResult(false);
        }
    }
}

/// <summary>
/// Represents a command for updating a product.
/// </summary>
public record UpdateProductCommand(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price) : ICommand<UpdateProductResult>;

/// <summary>
/// Represents the result of a updated product.
/// </summary>
public record UpdateProductResult(bool IsSuccess);