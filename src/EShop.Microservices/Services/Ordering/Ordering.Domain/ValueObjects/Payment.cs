// <fileheader>
//     <copyright file="Payment.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Domain.ValueObjects;

/// <summary>
/// Represents a payment value object in the system.
/// </summary>
public record Payment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Payment"/> class.
    /// </summary>
    protected Payment()
    {
    }

    /// <summary>
    /// Prevents a default instance of the <see cref="Payment"/> class from being created.
    /// </summary>
    /// <param name="cardName">The name on the card.</param>
    /// <param name="cardNumber">The card number.</param>
    /// <param name="expiration">The expiration date of the card.</param>
    /// <param name="cvv">The CVV code of the card.</param>
    /// <param name="paymentMethod">The payment method identifier.</param>
    private Payment(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }

    /// <summary>
    /// Gets the name on the payment card.
    /// </summary>
    public string? CardName { get; } = default!;

    /// <summary>
    /// Gets the payment card number.
    /// </summary>
    public string CardNumber { get; } = default!;

    /// <summary>
    /// Gets the expiration date of the payment card.
    /// </summary>
    public string Expiration { get; } = default!;

    /// <summary>
    /// Gets the CVV code of the payment card.
    /// </summary>
    public string CVV { get; } = default!;

    /// <summary>
    /// Gets the payment method identifier.
    /// </summary>
    public int PaymentMethod { get; } = default!;

    /// <summary>
    /// Creates a new <see cref="Payment"/> instance with the specified details.
    /// </summary>
    /// <param name="cardName">The name on the card.</param>
    /// <param name="cardNumber">The card number.</param>
    /// <param name="expiration">The expiration date of the card.</param>
    /// <param name="cvv">The CVV code of the card.</param>
    /// <param name="paymentMethod">The payment method identifier.</param>
    /// <returns>A new <see cref="Payment"/> instance with the specified details.</returns>
    /// <exception cref="ArgumentException">Thrown if any required argument is null or whitespace.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if CVV length exceeds the standard of 3 digits.</exception>
    public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

        return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
    }
}