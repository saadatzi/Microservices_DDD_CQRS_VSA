// <fileheader>
//     <copyright file="AddressDto.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Dtos;

/// <summary>
/// Represents an address data transfer object (DTO) containing address details.
/// </summary>
/// <param name="FirstName">The first name of the recipient.</param>
/// <param name="LastName">The last name of the recipient.</param>
/// <param name="EmailAddress">The email address associated with the address.</param>
/// <param name="AddressLine">The address line (e.g., street address) of the recipient.</param>
/// <param name="Country">The country where the address is located.</param>
/// <param name="State">The state or region of the address.</param>
/// <param name="ZipCode">The postal or zip code of the address.</param>
public record AddressDto(
    string FirstName,
    string LastName,
    string EmailAddress,
    string AddressLine,
    string Country,
    string State,
    string ZipCode);