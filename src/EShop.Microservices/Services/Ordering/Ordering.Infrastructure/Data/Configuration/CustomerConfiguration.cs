// <fileheader>
//     <copyright file="CustomerConfiguration.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace Ordering.Infrastructure.Data.Configurations;

/// <summary>
/// Provides configuration settings for the <see cref="Customer"/> entity in the database.
/// </summary>
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    /// <summary>
    /// Configures the database mapping for the Customer entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the Customer entity.</param>
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Sets the primary key for the Customer entity.
        builder.HasKey(c => c.Id);

        // Configures the Id property to use a custom value conversion.
        builder.Property(c => c.Id).HasConversion(
            customerId => customerId!.Value,
            dbId => CustomerId.Of(dbId));

        // Configures the Name property with a maximum length of 100 characters and as required.
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

        // Configures the Email property with a maximum length of 255 characters.
        builder.Property(c => c.Email).HasMaxLength(255);

        // Adds a unique index on the Email property.
        builder.HasIndex(c => c.Email).IsUnique();
    }
}