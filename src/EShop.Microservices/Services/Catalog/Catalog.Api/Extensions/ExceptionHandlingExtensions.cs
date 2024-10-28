// <fileheader>
//     <copyright file="ExceptionHandlingExtensions.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Catalog.Api.Extensions;

/// <summary>
/// Provides extension methods for configuring custom exception handling in an ASP.NET Core application.
/// </summary>
public static class ExceptionHandlingExtensions
{
    /// <summary>
    /// Configures a custom exception handler to log errors and return a JSON-formatted problem details response.
    /// </summary>
    /// <param name="app">The application builder.</param>
    public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                if (exception == null)
                {
                    return;
                }

                var problemDetails = new ProblemDetails
                {
                    Title = exception.Message,
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = exception.StackTrace,
                };

                var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                logger.LogError(exception, exception.Message);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/problem+json";

                await context.Response.WriteAsJsonAsync(problemDetails);
            });
        });
    }
}