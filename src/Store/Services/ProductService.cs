using Store.Models;

namespace Store.Services;

public class ProductService
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Coffee Mug", Description = "Ceramic coffee mug with logo", Price = 12.99m, ImageUrl = "/images/mug.jpg", Stock = 50, Category = "Kitchenware" },
        new Product { Id = 2, Name = "T-Shirt", Description = "Cotton t-shirt with logo", Price = 19.99m, ImageUrl = "/images/tshirt.jpg", Stock = 100, Category = "Clothing" },
        new Product { Id = 3, Name = "Notebook", Description = "Lined notebook with leather cover", Price = 9.99m, ImageUrl = "/images/notebook.jpg", Stock = 75, Category = "Stationery" },
        new Product { Id = 4, Name = "Water Bottle", Description = "Stainless steel water bottle", Price = 15.99m, ImageUrl = "/images/bottle.jpg", Stock = 60, Category = "Kitchenware" },
        new Product { Id = 5, Name = "Tote Bag", Description = "Canvas tote bag with logo", Price = 8.99m, ImageUrl = "/images/totebag.jpg", Stock = 40, Category = "Accessories" }
    };

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public Product? GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}