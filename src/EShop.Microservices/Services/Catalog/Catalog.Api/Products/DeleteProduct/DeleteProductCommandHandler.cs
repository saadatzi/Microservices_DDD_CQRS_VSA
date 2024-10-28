// <fileheader>
//     <copyright file="DeleteProductCommandHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Catalog.Api.Products.DeleteProduct;

using Catalog.Api.Exceptions;

/// <summary>
/// Handles the delete of a product.
/// </summary>
internal class DeleteProductCommandHandler(
    IDocumentSession session,
    ILogger<DeleteProductCommandHandler> logger)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    /// <summary>
    /// Handles the product delete based on the provided command.
    /// </summary>
    /// <param name="command">The delete product command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation and returns the deleted product result.</returns>
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        // Delete the product entity from command object
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product == null)
        {
            throw new ProductNotFoundException($"Product with Id number of {command.Id} is not found to delete.");
        }

        // save to database
        session.Delete(product);
        try
        {
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting the product with ID {ProductId}", command.Id);
            return new DeleteProductResult(false);
        }
    }
}

/// <summary>
/// Represents a command for updating a product.
/// </summary>
public record DeleteProductCommand(Guid Id)
    : ICommand<DeleteProductResult>;

/// <summary>
/// Represents the result of a updated product.
/// </summary>
public record DeleteProductResult(bool IsSuccess);