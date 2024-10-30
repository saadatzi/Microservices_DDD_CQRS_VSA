// <fileheader>
//     <copyright file="Coupon.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Discount.Grpc.Models;

/// <summary>
/// The Coupon class represents a discount coupon entity in the Discount microservice.
/// </summary>
public class Coupon
{
    /// <summary>
    /// Gets or sets the unique identifier of the coupon.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product to which the coupon is applicable.
    /// </summary>
    public string ProductName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the description of the coupon.
    /// Provides details on the nature of the discount or offer.
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Gets or sets the discount amount provided by the coupon.
    /// This represents the value of the discount in monetary terms.
    /// </summary>
    public int Amount { get; set; }
}