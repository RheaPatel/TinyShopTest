using DataEntities;

namespace Products.API.Services;

public class ProductService
{
    private readonly List<Product> _products;
    
    public ProductService()
    {
        // Initialize with some sample products
        _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Bluetooth Headphones",
                Description = "Wireless headphones with noise cancellation",
                Price = 89.99m,
                ImageUrl = "https://via.placeholder.com/300",
                StockQuantity = 45,
                Category = "Electronics"
            },
            new Product
            {
                Id = 2,
                Name = "Laptop Backpack",
                Description = "Waterproof backpack for laptops up to 15.6 inches",
                Price = 49.99m,
                ImageUrl = "https://via.placeholder.com/300",
                StockQuantity = 30,
                Category = "Accessories"
            },
            new Product
            {
                Id = 3,
                Name = "Coffee Maker",
                Description = "Automatic coffee maker with timer",
                Price = 119.99m,
                ImageUrl = "https://via.placeholder.com/300",
                StockQuantity = 15,
                Category = "Home Appliances"
            },
            new Product
            {
                Id = 4,
                Name = "Fitness Tracker",
                Description = "Tracks steps, heart rate, and sleep patterns",
                Price = 59.99m,
                ImageUrl = "https://via.placeholder.com/300",
                StockQuantity = 25,
                Category = "Electronics"
            },
            new Product
            {
                Id = 5,
                Name = "Desk Lamp",
                Description = "Adjustable LED desk lamp with USB charging port",
                Price = 39.99m,
                ImageUrl = "https://via.placeholder.com/300",
                StockQuantity = 40,
                Category = "Home Appliances"
            }
        };
    }
    
    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
    
    public Product? GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}