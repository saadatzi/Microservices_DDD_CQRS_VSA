// <fileheader>
//     <copyright file="ProductConfiguration.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Infrastructure.Data.Configurations;

/// <summary>
/// Provides configuration settings for the <see cref="Product"/> entity in the database.
/// </summary>
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    /// <summary>
    /// Configures the database mapping for the Product entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the Product entity.</param>
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Sets the primary key for the Product entity.
        builder.HasKey(p => p.Id);

        // Configures the Id property to use a custom value conversion.
        builder.Property(p => p.Id).HasConversion(
            productId => productId!.Value,
            dbId => ProductId.Of(dbId));

        // Configures the Name property with a maximum length of 100 characters and as required.
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
    }
}