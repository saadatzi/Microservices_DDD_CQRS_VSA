// <fileheader>
//     <copyright file="CustomValidationException.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

/// <summary>
/// Represents an exception that occurs when one or more validation errors are found.
/// </summary>
public class CustomValidationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomValidationException"/> class with a specified error message.
    /// </summary>
    /// <param name="errors">A collection of validation error messages.</param>
    public CustomValidationException(IEnumerable<string> errors)
        : base("One or more validation errors occurred.")
    {
        Errors = errors;
    }

    /// <summary>
    /// Gets a collection of validation error messages.
    /// </summary>
    public IEnumerable<string> Errors { get; }
}