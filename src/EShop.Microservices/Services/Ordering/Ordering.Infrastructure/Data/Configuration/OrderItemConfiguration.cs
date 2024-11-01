// <fileheader>
//     <copyright file="OrderItemConfiguration.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Infrastructure.Data.Configurations;

/// <summary>
/// Provides configuration settings for the <see cref="OrderItem"/> entity in the database.
/// </summary>
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    /// <summary>
    /// Configures the database mapping for the OrderItem entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the OrderItem entity.</param>
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        // Sets the primary key for the OrderItem entity.
        builder.HasKey(oi => oi.Id);

        // Configures the Id property to use a custom value conversion.
        builder.Property(oi => oi.Id).HasConversion(
            orderItemId => orderItemId!.Value,
            dbId => OrderItemId.Of(dbId));

        // Sets up a relationship between OrderItem and Product entities.
        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(oi => oi.ProductId);

        // Configures the Quantity property as required.
        builder.Property(oi => oi.Quantity).IsRequired();

        // Configures the Price property as required.
        builder.Property(oi => oi.Price).IsRequired();
    }
}