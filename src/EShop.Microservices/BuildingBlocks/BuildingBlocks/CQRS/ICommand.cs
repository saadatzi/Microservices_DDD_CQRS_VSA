// <fileheader>
//     <copyright file="ICommand.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace BuildingBlocks.CQRS;

using MediatR;

/// <summary>
/// Represents a command that does not return a result.
/// </summary>
public interface ICommand : IRequest<Unit>
{
}

/// <summary>
/// Represents a command that returns a result of type TResponse.
/// </summary>
/// <typeparam name="TResponse">The type of the response returned by the command.</typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}