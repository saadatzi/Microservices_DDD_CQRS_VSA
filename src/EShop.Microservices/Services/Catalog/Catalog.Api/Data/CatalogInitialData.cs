// <fileheader>
//     <copyright file="CatalogInitialData.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>

namespace Catalog.API.Data;

/// <summary>
/// Represents the initial data for the Catalog API, implementing the <see cref="IInitialData"/> interface.
/// This class is responsible for populating the database with preconfigured product data.
/// </summary>
public class CatalogInitialData : IInitialData
{
    /// <summary>
    /// Populates the database with initial data.
    /// This method checks if any products already exist in the database.
    /// If no products are found, it stores the preconfigured products.
    /// </summary>
    /// <param name="store">The document store used to interact with the database.</param>
    /// <param name="cancellation">A cancellation token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        // Check if any products already exist in the database
        if (await session.Query<Product>().AnyAsync(cancellation))
        {
            return;
        }

        // Marten UPSERT will cater for existing records
        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    /// <summary>
    /// Returns a list of preconfigured products to seed the database.
    /// </summary>
    /// <returns>An enumerable list of preconfigured products.</returns>
    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
    {
        new Product
        {
            Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
            Name = "IPhone X",
            Description = "This phone is the company's biggest change to its flagship smartphone.",
            ImageFile = "product-1.png",
            Price = 950.00M,
            Category = { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
            Name = "Samsung 10",
            Description = "This phone is the company's biggest change to its flagship smartphone.",
            ImageFile = "product-2.png",
            Price = 840.00M,
            Category =
            [
                "Smart Phone"
            ],
        },
        new Product
        {
            Id = new Guid("9f9c12e3-e4d1-4c76-8ae1-b12ee4bbd1c5"),
            Name = "Google Pixel 5",
            Description = "The Google Pixel 5 offers a new design and improved camera features.",
            ImageFile = "product-3.png",
            Price = 699.00M,
            Category = new List<string> { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("e9d35f73-a31c-46ed-b8c5-246e4aef4f24"),
            Name = "OnePlus 8T",
            Description = "The OnePlus 8T is a fast and affordable smartphone.",
            ImageFile = "product-4.png",
            Price = 749.00M,
            Category = new List<string> { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("e1de7c1c-68f1-42b7-93c0-8e69af1c8c01"),
            Name = "Xiaomi Mi 10",
            Description = "The Xiaomi Mi 10 brings powerful performance at a competitive price.",
            ImageFile = "product-5.png",
            Price = 699.99M,
            Category = new List<string> { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("76f8d048-1e5e-47d9-abc1-8d0f30f86e4c"),
            Name = "Nokia 8.3",
            Description = "Nokia's 8.3 smartphone features a large display and a solid camera.",
            ImageFile = "product-6.png",
            Price = 699.00M,
            Category = new List<string> { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("3c1c24f4-8df1-48f7-a4cd-e9f1f47cd267"),
            Name = "Sony Xperia 1 II",
            Description = "The Xperia 1 II is a flagship phone with an impressive camera.",
            ImageFile = "product-7.png",
            Price = 1299.00M,
            Category = new List<string> { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("4c4e4781-77c5-4971-8eb9-df1f7c21ab9f"),
            Name = "Motorola Moto G Power",
            Description = "The Moto G Power is known for its long battery life.",
            ImageFile = "product-8.png",
            Price = 249.99M,
            Category = new List<string> { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("a68c2dc7-c255-42c4-87d5-144d4a0325eb"),
            Name = "Huawei P40 Pro",
            Description = "The Huawei P40 Pro has a sophisticated camera system.",
            ImageFile = "product-9.png",
            Price = 999.00M,
            Category = new List<string> { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("b8f3deec-63c8-4d59-bada-bd8cb78b9ec7"),
            Name = "LG V60 ThinQ",
            Description = "The LG V60 ThinQ offers premium features for audio and video.",
            ImageFile = "product-10.png",
            Price = 799.99M,
            Category = new List<string> { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("a2c55ae3-8778-44cb-9435-72ff8b5c28c5"),
            Name = "Oppo Find X2 Pro",
            Description = "The Oppo Find X2 Pro is an impressive flagship device.",
            ImageFile = "product-11.png",
            Price = 1149.00M,
            Category = new List<string> { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("0d291d62-299f-4977-8120-550b1834d82e"),
            Name = "ASUS ROG Phone 3",
            Description = "The ASUS ROG Phone 3 is designed for mobile gaming.",
            ImageFile = "product-12.png",
            Price = 999.00M,
            Category = new List<string> { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("6cc40a52-4601-4a7c-947e-9e0b5d1ed949"),
            Name = "ZTE Axon 20",
            Description = "The ZTE Axon 20 features an under-display camera.",
            ImageFile = "product-13.png",
            Price = 649.99M,
            Category = new List<string> { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("59317d0a-7b9c-4a7e-b4ab-2f4f4a5989bc"),
            Name = "Vivo V20",
            Description = "The Vivo V20 is known for its sleek design and good camera.",
            ImageFile = "product-14.png",
            Price = 299.99M,
            Category = new List<string> { "Smart Phone" },
        },
        new Product
        {
            Id = new Guid("cc2b0070-38c7-4e47-a1ab-eaa006ed5949"),
            Name = "Realme X50 Pro",
            Description = "The Realme X50 Pro is a flagship smartphone with great value.",
            ImageFile = "product-15.png",
            Price = 699.00M,
            Category = new List<string> { "Smart Phone" },
        },
    };
}