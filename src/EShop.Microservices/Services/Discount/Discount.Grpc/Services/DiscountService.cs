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
    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();

        if (coupon == null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));
        }

        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation($"Discount is successfully created. productName : {coupon.ProductName}, amount: {coupon.Amount}");
        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel!;
    }

    /// <summary>
    /// Updates an existing discount based on the provided request.
    /// </summary>
    /// <param name="request">The request containing updated discount details.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A <see cref="CouponModel"/> representing the updated discount.</returns>
    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();

        if (coupon == null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));
        }

        dbContext.Coupons.Update(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation($"Discount is updated successfully. productName: {coupon.ProductName}, amount: {coupon.Amount}");
        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    /// <summary>
    /// Deletes a discount based on the provided request.
    /// </summary>
    /// <param name="request">The request containing the discount identifier to delete.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A <see cref="DeleteDiscountResponse"/> indicating success or failure.</returns>
    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext
            .Coupons
            .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (coupon == null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object"));
        }

        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation($"Discount is removed successfully. productName: {coupon.ProductName}, amount: {coupon.Amount}");

        return new DeleteDiscountResponse { Success = true };
    }
}