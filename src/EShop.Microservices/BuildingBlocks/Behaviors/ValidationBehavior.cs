// <fileheader>
//     <copyright file="ValidationBehavior.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviors;

/// <summary>
/// Represents a pipeline behavior that performs validation on a request using FluentValidation validators.
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public class ValidationBehavior<TRequest, TResponse>
    (IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    /// <summary>
    /// Handles the request validation before passing it down the pipeline.
    /// </summary>
    /// <param name="request">The request instance to be validated.</param>
    /// <param name="next">The delegate for the next behavior in the pipeline.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The response of the request handler if validation passes; otherwise, throws a <see cref="ValidationException"/>.</returns>
    /// <exception cref="ValidationException">Thrown if one or more validation failures are found.</exception>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Create a validation context for the request
        var context = new ValidationContext<TRequest>(request);

        // Execute all validators asynchronously
        var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        // Collect validation failures
        var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .ToList();

        // If there are any validation failures, throw an exception
        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        // Proceed to the next behavior in the pipeline
        return await next();
    }
}