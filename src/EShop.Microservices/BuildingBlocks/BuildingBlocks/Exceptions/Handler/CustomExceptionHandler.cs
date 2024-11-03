// <fileheader>
//     <copyright file="CustomExceptionHandler.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace BuildingBlocks.Exceptions.Handler;

using System.Threading;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

/// <summary>
/// Provides a custom exception handler to log and process exceptions occurring within the application.
/// </summary>
public class CustomExceptionHandler : IExceptionHandler
{
    private readonly ILogger<CustomExceptionHandler> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomExceptionHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance to log exception details.</param>
    public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
    {
        this.logger = logger;
    }

    /// <summary>
    /// Attempts to handle the exception asynchronously, logging details and returning a specific status code.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="exception">The exception to handle.</param>
    /// <param name="cancellationToken">The cancellation token for the async operation.</param>
    /// <returns>A <see cref="ValueTask{TResult}"/> representing the asynchronous operation with a result indicating whether the exception was handled.</returns>
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(
            "Error Message: {exceptionMessage}, Time of occurrence {time}",
            exception.Message,
            DateTime.UtcNow);

        // Set up custom problem details depending on the exception type.
        var (detail, title, statusCode) = exception switch
        {
            InternalServerException => (
                Detail: exception.Message,
                Title: exception.GetType().Name,
                StatusCode: StatusCodes.Status500InternalServerError),
            ValidationException => (
                Detail: exception.Message,
                Title: exception.GetType().Name,
                StatusCode: StatusCodes.Status400BadRequest),
            BadRequestException => (
                Detail: exception.Message,
                Title: exception.GetType().Name,
                StatusCode: StatusCodes.Status400BadRequest),
            NotFoundException => (
                Detail: exception.Message,
                Title: exception.GetType().Name,
                StatusCode: StatusCodes.Status404NotFound),
            _ => (
                Detail: "An unexpected error occurred.",
                Title: "Unexpected Error",
                StatusCode: StatusCodes.Status500InternalServerError),
        };

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/problem+json";

        var problemDetails = new ProblemDetails
        {
            Title = title,
            Detail = detail,
            Status = statusCode,
            Instance = context.Request.Path,
        };

        problemDetails.Extensions.Add("traceId", context.TraceIdentifier);

        if (exception is ValidationException validationException)
        {
            problemDetails.Extensions.Add("ValidationError", validationException.Errors);
        }

        await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);
        return true;
    }
}