using System.Net.Http.Json;
using TinyShop.Shared.Models;

namespace TinyShop.Web.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<List<Product>> GetProductsAsync()
    {
        // For now, return mock data to demonstrate UI
        List<Product> products = new()
        {
            new Product 
            { 
                Id = 1, 
                Name = "Smartphone X", 
                Description = "Latest smartphone with advanced features", 
                Price = 999.99m, 
                ImageUrl = "/images/smartphone.svg", 
                Rating = 5, 
                InStock = true 
            },
            new Product 
            { 
                Id = 2, 
                Name = "Laptop Pro", 
                Description = "Powerful laptop for professionals", 
                Price = 1499.99m, 
                ImageUrl = "/images/laptop.svg", 
                Rating = 4, 
                InStock = true 
            },
            new Product 
            { 
                Id = 3, 
                Name = "Wireless Earbuds", 
                Description = "High-quality wireless earbuds", 
                Price = 149.99m, 
                ImageUrl = "/images/earbuds.svg", 
                Rating = 4, 
                InStock = true 
            },
            new Product 
            { 
                Id = 4, 
                Name = "Smart Watch", 
                Description = "Fitness and health tracking smart watch", 
                Price = 249.99m, 
                ImageUrl = "/images/smartwatch.svg", 
                Rating = 3, 
                InStock = false 
            },
            new Product 
            { 
                Id = 5, 
                Name = "Bluetooth Speaker", 
                Description = "Portable Bluetooth speaker with great sound", 
                Price = 89.99m, 
                ImageUrl = "/images/speaker.svg", 
                Rating = 5, 
                InStock = true 
            },
            new Product 
            { 
                Id = 6, 
                Name = "Gaming Console", 
                Description = "Next-gen gaming console", 
                Price = 499.99m, 
                ImageUrl = "/images/console.svg", 
                Rating = 5, 
                InStock = false 
            }
        };

        return Task.FromResult(products);

        // In a real application we would call the API
        // try
        // {
        //     return await _httpClient.GetFromJsonAsync<List<Product>>("api/products") ?? new List<Product>();
        // }
        // catch (Exception)
        // {
        //     // Log the error
        //     return new List<Product>();
        // }
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
        }
        catch (Exception)
        {
            // Log the error
            return null;
        }
    }
}