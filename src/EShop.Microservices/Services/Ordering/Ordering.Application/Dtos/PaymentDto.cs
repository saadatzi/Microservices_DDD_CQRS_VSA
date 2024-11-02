// <fileheader>
//     <copyright file="PaymentDto.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Application.Dtos;

/// <summary>
/// Represents a payment data transfer object (DTO) containing payment details.
/// </summary>
/// <param name="CardName">The name on the payment card.</param>
/// <param name="CardNumber">The number of the payment card.</param>
/// <param name="Expiration">The expiration date of the payment card.</param>
/// <param name="Cvv">The CVV code of the payment card.</param>
/// <param name="PaymentMethod">The method of payment, represented as an integer.</param>
public record PaymentDto(
    string CardName,
    string CardNumber,
    string Expiration,
    string Cvv,
    int PaymentMethod);