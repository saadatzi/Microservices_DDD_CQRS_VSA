// <fileheader>
//     <copyright file="DeleteBasketHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Basket.API.Basket.DeleteBasket;

/// <summary>
/// Command handler for processing delete basket commands.
/// </summary>
public class DeleteBasketHandler(IBasketRepository basketRepository)
    : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    /// <summary>
    /// Handles the delete basket command asynchronously.
    /// </summary>
    /// <param name="command">The command containing the basket to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the result of the delete operation.</returns>
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        // TODO: delete basket from database and cache
        await basketRepository.DeleteBasket(command.UserName, cancellationToken);
        return new DeleteBasketResult(true);
    }
}

/// <summary>
/// Represents the command to delete a basket.
/// </summary>
/// <param name="UserName">The username associated with the basket to be deleted.</param>
public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

/// <summary>
/// Represents the result of the delete basket command.
/// </summary>
/// <param name="IsSuccess">Indicates whether the delete operation was successful.</param>
public record DeleteBasketResult(bool IsSuccess);