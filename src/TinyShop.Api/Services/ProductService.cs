using TinyShop.Api.Models;

namespace TinyShop.Api.Services;

public class ProductService
{
    private static readonly List<Product> _products = new()
    {
        new Product 
        { 
            Id = 1, 
            Name = "Smartphone X", 
            Description = "Latest smartphone with advanced features", 
            Price = 999.99m, 
            ImageUrl = "/images/smartphone.jpg", 
            Rating = 5, 
            InStock = true 
        },
        new Product 
        { 
            Id = 2, 
            Name = "Laptop Pro", 
            Description = "Powerful laptop for professionals", 
            Price = 1499.99m, 
            ImageUrl = "/images/laptop.jpg", 
            Rating = 4, 
            InStock = true 
        },
        new Product 
        { 
            Id = 3, 
            Name = "Wireless Earbuds", 
            Description = "High-quality wireless earbuds", 
            Price = 149.99m, 
            ImageUrl = "/images/earbuds.jpg", 
            Rating = 4, 
            InStock = true 
        },
        new Product 
        { 
            Id = 4, 
            Name = "Smart Watch", 
            Description = "Fitness and health tracking smart watch", 
            Price = 249.99m, 
            ImageUrl = "/images/smartwatch.jpg", 
            Rating = 3, 
            InStock = false 
        },
        new Product 
        { 
            Id = 5, 
            Name = "Bluetooth Speaker", 
            Description = "Portable Bluetooth speaker with great sound", 
            Price = 89.99m, 
            ImageUrl = "/images/speaker.jpg", 
            Rating = 5, 
            InStock = true 
        },
        new Product 
        { 
            Id = 6, 
            Name = "Gaming Console", 
            Description = "Next-gen gaming console", 
            Price = 499.99m, 
            ImageUrl = "/images/console.jpg", 
            Rating = 5, 
            InStock = false 
        }
    };

    public IEnumerable<Product> GetAllProducts() => _products;

    public Product? GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);
}