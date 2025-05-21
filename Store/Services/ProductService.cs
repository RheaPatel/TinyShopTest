using TinyShop.DataEntities;

namespace TinyShop.Store.Services;

/// <summary>
/// Service to manage products in the TinyShop application.
/// </summary>
public class ProductService
{
    private readonly List<Product> _products;
    private readonly IConfiguration _configuration;
    
    /// <summary>
    /// Initializes a new instance of the ProductService class.
    /// </summary>
    /// <param name="configuration">Application configuration.</param>
    public ProductService(IConfiguration configuration)
    {
        _configuration = configuration;
        // Sample product data - in a real application, this would come from a database
        _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Coffee Mug",
                Description = "Ceramic coffee mug with TinyShop logo",
                Price = 12.99m,
                ImageFileName = "mug.jpg",
                Category = "Kitchenware",
                InStock = true,
                StockQuantity = 50
            },
            new Product
            {
                Id = 2,
                Name = "T-Shirt",
                Description = "100% cotton t-shirt with TinyShop logo",
                Price = 19.99m,
                ImageFileName = "tshirt.jpg",
                Category = "Apparel",
                InStock = true,
                StockQuantity = 30
            },
            new Product
            {
                Id = 3,
                Name = "Notebook",
                Description = "Spiral-bound notebook with TinyShop logo",
                Price = 7.99m,
                ImageFileName = "notebook.jpg",
                Category = "Office",
                InStock = true,
                StockQuantity = 100
            },
            new Product
            {
                Id = 4,
                Name = "Backpack",
                Description = "Durable backpack with multiple compartments",
                Price = 49.99m,
                ImageFileName = "backpack.jpg",
                Category = "Accessories",
                InStock = true,
                StockQuantity = 15
            },
            new Product
            {
                Id = 5,
                Name = "Water Bottle",
                Description = "Stainless steel insulated water bottle",
                Price = 24.99m,
                ImageFileName = "bottle.jpg",
                Category = "Kitchenware",
                InStock = true,
                StockQuantity = 40
            }
        };
    }

    /// <summary>
    /// Gets all products.
    /// </summary>
    /// <returns>A list of all products.</returns>
    public List<Product> GetAllProducts()
    {
        return _products;
    }

    /// <summary>
    /// Gets a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to get.</param>
    /// <returns>The product with the specified ID, or null if not found.</returns>
    public Product? GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
    
    /// <summary>
    /// Gets products by category.
    /// </summary>
    /// <param name="category">The category to filter by.</param>
    /// <returns>A list of products in the specified category.</returns>
    public List<Product> GetProductsByCategory(string category)
    {
        return _products.Where(p => p.Category == category).ToList();
    }
    
    /// <summary>
    /// Gets the image URL for a product.
    /// </summary>
    /// <param name="product">The product to get the image URL for.</param>
    /// <returns>The URL of the product image.</returns>
    public string GetProductImageUrl(Product product)
    {
        if (string.IsNullOrEmpty(product.ImageFileName))
        {
            return "/images/placeholder.jpg";
        }
        
        string imagePrefix = _configuration["ImagePrefix"] ?? "";
        return $"{imagePrefix}/images/{product.ImageFileName}";
    }
}