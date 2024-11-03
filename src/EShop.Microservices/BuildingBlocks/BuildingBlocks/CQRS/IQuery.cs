// <fileheader>
//     <copyright file="IQuery.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace BuildingBlocks.CQRS;

using MediatR;

/// <summary>
/// Represents a query that returns a result.
/// </summary>
/// <typeparam name="TResponse">The type of the response returned by this query.</typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
}