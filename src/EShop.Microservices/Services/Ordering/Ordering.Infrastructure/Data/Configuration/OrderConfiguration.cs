// <fileheader>
//     <copyright file="OrderConfiguration.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Infrastructure.Data.Configurations;

/// <summary>
/// Configuration class for the <see cref="Order"/> entity.
/// Maps and configures properties, relationships, and complex types for database schema.
/// </summary>
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    /// <summary>
    /// Configures the database schema for the <see cref="Order"/> entity.
    /// </summary>
    /// <param name="builder">The builder to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Primary key configuration
        builder.HasKey(o => o.Id);

        // Property configuration for Order ID with custom conversion
        builder.Property(o => o.Id).HasConversion(
            orderId => orderId!.Value,
            dbId => OrderId.Of(dbId));

        // Foreign key relationship configuration with Customer entity
        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired();

        // One-to-Many relationship configuration with OrderItems
        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId);

        // Configuration for OrderName as a complex property
        builder.ComplexProperty(
            o => o.OrderName, nameBuilder =>
        {
            nameBuilder.Property(n => n.Value)
                .HasColumnName(nameof(Order.OrderName))
                .HasMaxLength(100)
                .IsRequired();
        });

        // Configuration for ShippingAddress as a complex property
        builder.ComplexProperty(
            o => o.ShippingAddress, addressBuilder =>
        {
            addressBuilder.Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            addressBuilder.Property(a => a.LastName)
                .HasMaxLength(50)
                .IsRequired();

            addressBuilder.Property(a => a.EmailAddress)
                .HasMaxLength(50);

            addressBuilder.Property(a => a.AddressLine)
                .HasMaxLength(180)
                .IsRequired();

            addressBuilder.Property(a => a.Country)
                .HasMaxLength(50);

            addressBuilder.Property(a => a.State)
                .HasMaxLength(50);

            addressBuilder.Property(a => a.ZipCode)
                .HasMaxLength(5)
                .IsRequired();
        });

        // Configuration for BillingAddress as a complex property
        builder.ComplexProperty(
            o => o.BillingAddress, addressBuilder =>
        {
            addressBuilder.Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            addressBuilder.Property(a => a.LastName)
                .HasMaxLength(50)
                .IsRequired();

            addressBuilder.Property(a => a.EmailAddress)
                .HasMaxLength(50);

            addressBuilder.Property(a => a.AddressLine)
                .HasMaxLength(180)
                .IsRequired();

            addressBuilder.Property(a => a.Country)
                .HasMaxLength(50);

            addressBuilder.Property(a => a.State)
                .HasMaxLength(50);

            addressBuilder.Property(a => a.ZipCode)
                .HasMaxLength(5)
                .IsRequired();
        });

        // Configuration for Payment as a complex property
        builder.ComplexProperty(
            o => o.Payment, paymentBuilder =>
        {
            paymentBuilder.Property(p => p.CardName)
                .HasMaxLength(50);

            paymentBuilder.Property(p => p.CardNumber)
                .HasMaxLength(24)
                .IsRequired();

            paymentBuilder.Property(p => p.Expiration)
                .HasMaxLength(10);

            paymentBuilder.Property(p => p.CVV)
                .HasMaxLength(3);

            paymentBuilder.Property(p => p.PaymentMethod);
        });

        // Configuration for Status with default value and conversion
        builder.Property(o => o.Status)
            .HasDefaultValue(OrderStatus.Draft)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

        builder.Property(o => o.TotalPrice);
    }
}