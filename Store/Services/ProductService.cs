using DataEntities;

namespace Store.Services;

/// <summary>
/// Service to provide product data
/// </summary>
public class ProductService
{
    private readonly List<Product> _products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Coffee Mug",
            Description = "A ceramic coffee mug with the TinyShop logo.",
            Price = 12.99m,
            ImageUrl = "images/coffee-mug.jpg",
            Category = "Kitchen",
            IsAvailable = true
        },
        new Product
        {
            Id = 2,
            Name = "T-Shirt",
            Description = "A comfortable cotton T-shirt with the TinyShop logo.",
            Price = 19.99m,
            ImageUrl = "images/tshirt.jpg",
            Category = "Clothing",
            IsAvailable = true
        },
        new Product
        {
            Id = 3,
            Name = "Notebook",
            Description = "A spiral-bound notebook with the TinyShop logo.",
            Price = 5.99m,
            ImageUrl = "images/notebook.jpg",
            Category = "Office",
            IsAvailable = true
        },
        new Product
        {
            Id = 4,
            Name = "Water Bottle",
            Description = "A stainless steel water bottle with the TinyShop logo.",
            Price = 15.99m,
            ImageUrl = "images/water-bottle.jpg",
            Category = "Kitchen",
            IsAvailable = true
        },
        new Product
        {
            Id = 5,
            Name = "Tote Bag",
            Description = "A canvas tote bag with the TinyShop logo.",
            Price = 9.99m,
            ImageUrl = "images/tote-bag.jpg",
            Category = "Accessories",
            IsAvailable = true
        }
    };

    /// <summary>
    /// Get all products
    /// </summary>
    /// <returns>A list of all products</returns>
    public IReadOnlyList<Product> GetProducts() => _products.AsReadOnly();

    /// <summary>
    /// Get a product by ID
    /// </summary>
    /// <param name="id">The ID of the product to get</param>
    /// <returns>The product with the specified ID, or null if not found</returns>
    public Product? GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);
}