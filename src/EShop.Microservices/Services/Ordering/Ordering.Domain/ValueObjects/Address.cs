// <fileheader>
//     <copyright file="Address.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Domain.ValueObjects;

/// <summary>
/// Represents an address value object in the system.
/// </summary>
public record Address
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Address"/> class.
    /// </summary>
    protected Address()
    {
    }

    /// <summary>
    /// Prevents a default instance of the <see cref="Address"/> class from being created.
    /// </summary>
    /// <param name="firstName">The first name associated with the address.</param>
    /// <param name="lastName">The last name associated with the address.</param>
    /// <param name="emailAddress">The email address associated with the address.</param>
    /// <param name="addressLine">The address line.</param>
    /// <param name="country">The country associated with the address.</param>
    /// <param name="state">The state associated with the address.</param>
    /// <param name="zipCode">The zip code associated with the address.</param>
    private Address(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    /// <summary>
    /// Gets the first name associated with the address.
    /// </summary>
    public string FirstName { get; } = default!;

    /// <summary>
    /// Gets the last name associated with the address.
    /// </summary>
    public string LastName { get; } = default!;

    /// <summary>
    /// Gets the email address associated with the address.
    /// </summary>
    public string? EmailAddress { get; } = default!;

    /// <summary>
    /// Gets the address line.
    /// </summary>
    public string AddressLine { get; } = default!;

    /// <summary>
    /// Gets the country associated with the address.
    /// </summary>
    public string Country { get; } = default!;

    /// <summary>
    /// Gets the state associated with the address.
    /// </summary>
    public string State { get; } = default!;

    /// <summary>
    /// Gets the zip code associated with the address.
    /// </summary>
    public string ZipCode { get; } = default!;

    /// <summary>
    /// Creates a new <see cref="Address"/> instance with the specified details.
    /// </summary>
    /// <param name="firstName">The first name associated with the address.</param>
    /// <param name="lastName">The last name associated with the address.</param>
    /// <param name="emailAddress">The email address associated with the address.</param>
    /// <param name="addressLine">The address line.</param>
    /// <param name="country">The country associated with the address.</param>
    /// <param name="state">The state associated with the address.</param>
    /// <param name="zipCode">The zip code associated with the address.</param>
    /// <returns>A new <see cref="Address"/> instance with the specified details.</returns>
    public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);

        return new Address(firstName, lastName, emailAddress, addressLine, country, state, zipCode);
    }
}