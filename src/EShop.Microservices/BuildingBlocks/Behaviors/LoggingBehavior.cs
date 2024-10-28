// <fileheader>
//     <copyright file="LoggingBehavior.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace BuildingBlocks.Behaviors;

using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

/// <summary>
/// Represents a logging behavior that logs the request and response, along with the execution time.
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public class LoggingBehavior<TRequest, TResponse>
    (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    /// <summary>
    /// Handles the request by logging the start and end of processing, and timing the execution.
    /// </summary>
    /// <param name="request">The request object.</param>
    /// <param name="next">The next delegate in the request pipeline.</param>
    /// <param name="cancellationToken">The cancellation token for the asynchronous operation.</param>
    /// <returns>A <see cref="Task{TResponse}"/> representing the asynchronous operation, with the response object as the result.</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Log start of handling request
        logger.LogInformation(
            "[START] Handle request={Request} - ResponseType={Response} - RequestData={RequestData}",
            typeof(TRequest).Name,
            typeof(TResponse).Name,
            request);

        // Start timer
        var timer = new Stopwatch();
        timer.Start();

        // Process request and get response
        var response = await next();

        // Stop timer
        timer.Stop();
        var timeTaken = timer.Elapsed;

        // Log performance warning if time taken is greater than 3 seconds
        if (timeTaken.Seconds > 3)
        {
            logger.LogWarning(
                "[PERFORMANCE] The request {Request} took {TimeTaken} seconds.",
                typeof(TRequest).Name,
                timeTaken.Seconds);
        }

        // Log end of handling request
        logger.LogInformation("[END] Handled {Request} with {Response}", typeof(TRequest).Name, typeof(TResponse).Name);

        return response;
    }
}