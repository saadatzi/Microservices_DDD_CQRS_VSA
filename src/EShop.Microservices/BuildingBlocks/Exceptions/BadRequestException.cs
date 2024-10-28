// <fileheader>
//     <copyright file="BadRequestException.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace BuildingBlocks.Exceptions;

/// <summary>
/// Represents errors that occur when a bad request is made to the server.
/// </summary>
public class BadRequestException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public BadRequestException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class with a specified error message and additional details.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="details">Additional details about the error.</param>
    public BadRequestException(string message, string details)
        : base(message)
    {
        Details = details;
    }

    /// <summary>
    /// Gets additional details about the error.
    /// </summary>
    public string? Details { get; }
}