// <fileheader>
//     <copyright file="ICommandHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace BuildingBlocks.CQRS;

using MediatR;

/// <summary>
/// Represents a handler that processes a command without returning a response.
/// </summary>
/// <typeparam name="TCommand">The type of the command being handled.</typeparam>
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{
}

/// <summary>
/// Represents a handler that processes a command and returns a response.
/// </summary>
/// <typeparam name="TCommand">The type of the command being handled.</typeparam>
/// <typeparam name="TResponse">The type of the response returned by the handler.</typeparam>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
}