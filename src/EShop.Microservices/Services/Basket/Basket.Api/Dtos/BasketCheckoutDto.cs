// <fileheader>
//     <copyright file="BasketCheckoutDto.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Basket.API.Dtos;

/// <summary>
/// Data Transfer Object representing the checkout information for a basket.
/// </summary>
public class BasketCheckoutDto
{
    /// <summary>
    /// Gets or sets the username associated with the basket.
    /// </summary>
    public string UserName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the customer ID associated with the basket.
    /// </summary>
    public Guid CustomerId { get; set; } = default!;

    /// <summary>
    /// Gets or sets the total price of the basket.
    /// </summary>
    public decimal TotalPrice { get; set; } = default!;

    // Shipping and Billing Address

    /// <summary>
    /// Gets or sets the first name for the shipping or billing address.
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the last name for the shipping or billing address.
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the email address for the shipping or billing address.
    /// </summary>
    public string EmailAddress { get; set; } = default!;

    /// <summary>
    /// Gets or sets the address line for the shipping or billing address.
    /// </summary>
    public string AddressLine { get; set; } = default!;

    /// <summary>
    /// Gets or sets the country for the shipping or billing address.
    /// </summary>
    public string Country { get; set; } = default!;

    /// <summary>
    /// Gets or sets the state for the shipping or billing address.
    /// </summary>
    public string State { get; set; } = default!;

    /// <summary>
    /// Gets or sets the ZIP code for the shipping or billing address.
    /// </summary>
    public string ZipCode { get; set; } = default!;

    // Payment

    /// <summary>
    /// Gets or sets the card name for the payment.
    /// </summary>
    public string CardName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the card number for the payment.
    /// </summary>
    public string CardNumber { get; set; } = default!;

    /// <summary>
    /// Gets or sets the expiration date for the payment card.
    /// </summary>
    public string Expiration { get; set; } = default!;

    /// <summary>
    /// Gets or sets the CVV code for the payment card.
    /// </summary>
    public string CVV { get; set; } = default!;

    /// <summary>
    /// Gets or sets the payment method.
    /// </summary>
    public int PaymentMethod { get; set; } = default!;
}