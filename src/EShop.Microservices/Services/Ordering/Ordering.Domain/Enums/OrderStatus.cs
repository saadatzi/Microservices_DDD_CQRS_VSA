// <fileheader>
//     <copyright file="OrderStatus.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Ordering.Domain.Enums;

/// <summary>
/// Represents the various statuses an order can have.
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// Indicates that the order is in draft state.
    /// </summary>
    Draft = 1,

    /// <summary>
    /// Indicates that the order is pending and awaiting further actions.
    /// </summary>
    Pending = 2,

    /// <summary>
    /// Indicates that the order has been completed.
    /// </summary>
    Completed = 3,

    /// <summary>
    /// Indicates that the order has been cancelled.
    /// </summary>
    Cancelled = 4,
}