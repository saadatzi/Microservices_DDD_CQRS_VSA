// <fileheader>
//     <copyright file="BasketCheckoutEvent.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace BuildingBlocks.Messaging.Events;

/// <summary>
/// Event representing a basket checkout. This event is raised when a user completes the checkout process.
/// </summary>
public record BasketCheckoutEvent : IntegrationEvent
{
    /// <summary>
    /// Gets or sets the username of the customer performing the checkout.
    /// </summary>
    public string UserName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the unique customer identifier.
    /// </summary>
    public Guid CustomerId { get; set; } = default!;

    /// <summary>
    /// Gets or sets the total price of the basket.
    /// </summary>
    public decimal TotalPrice { get; set; } = default!;

    // Shipping and Billing Address details

    /// <summary>
    /// Gets or sets the first name of the recipient for shipping or billing.
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the last name of the recipient for shipping or billing.
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the email address of the recipient for shipping or billing.
    /// </summary>
    public string EmailAddress { get; set; } = default!;

    /// <summary>
    /// Gets or sets the address line for the shipping or billing address.
    /// </summary>
    public string AddressLine { get; set; } = default!;

    /// <summary>
    /// Gets or sets the country of the shipping or billing address.
    /// </summary>
    public string Country { get; set; } = default!;

    /// <summary>
    /// Gets or sets the state of the shipping or billing address.
    /// </summary>
    public string State { get; set; } = default!;

    /// <summary>
    /// Gets or sets the ZIP code of the shipping or billing address.
    /// </summary>
    public string ZipCode { get; set; } = default!;

    // Payment details

    /// <summary>
    /// Gets or sets the name on the card used for payment.
    /// </summary>
    public string CardName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the card number used for payment.
    /// </summary>
    public string CardNumber { get; set; } = default!;

    /// <summary>
    /// Gets or sets the expiration date of the card used for payment.
    /// </summary>
    public string Expiration { get; set; } = default!;

    /// <summary>
    /// Gets or sets the CVV code of the card used for payment.
    /// </summary>
    public string CVV { get; set; } = default!;

    /// <summary>
    /// Gets or sets the payment method identifier.
    /// </summary>
    public int PaymentMethod { get; set; } = default!;
}