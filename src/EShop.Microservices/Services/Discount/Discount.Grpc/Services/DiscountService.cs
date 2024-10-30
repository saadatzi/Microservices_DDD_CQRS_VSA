// <fileheader>
//     <copyright file="DiscountService.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Discount.Grpc.Services;

/// <summary>
/// Provides CRUD operations for managing discount coupons via gRPC.
/// Implements the methods defined in <see cref="DiscountProtoService.DiscountProtoServiceBase"/>.
/// </summary>
public class DiscountService
    (DiscountContext dbContext, ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    /// <summary>
    /// Retrieves a discount based on the provided request.
    /// </summary>
    /// <param name="request">The request containing discount details.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A <see cref="CouponModel"/> containing discount details.</returns>
    public async override Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext
            .Coupons
            .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (coupon == null)
        {
            coupon = new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
        }

        logger.LogInformation($"Discount is retrieved for productName : {coupon.ProductName}, amount: {coupon.Amount}");
        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel!;
    }

    /// <summary>
    /// Creates a new discount based on the provided request.
    /// </summary>
    /// <param name="request">The request containing new discount details.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A <see cref="CouponModel"/> representing the created discount.</returns>
    public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        // Placeholder for actual logic to create a discount
        return base.CreateDiscount(request, context);
    }

    /// <summary>
    /// Updates an existing discount based on the provided request.
    /// </summary>
    /// <param name="request">The request containing updated discount details.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A <see cref="CouponModel"/> representing the updated discount.</returns>
    public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        // Placeholder for actual logic to update a discount
        return base.UpdateDiscount(request, context);
    }

    /// <summary>
    /// Deletes a discount based on the provided request.
    /// </summary>
    /// <param name="request">The request containing the discount identifier to delete.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A <see cref="DeleteDiscountResponse"/> indicating success or failure.</returns>
    public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        // Placeholder for actual logic to delete a discount
        return base.DeleteDiscount(request, context);
    }
}