using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyShop.Web.Models;

namespace TinyShop.Web.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Adventurer GPS Watch",
                Description = "Rugged GPS watch for outdoor adventures",
                Price = 199.99m,
                ImageUrl = "images/products/watch.jpg",
                Category = "Accessories"
            },
            new Product
            {
                Id = 2,
                Name = "AeroLite Cycling Helmet",
                Description = "Lightweight cycling helmet with advanced protection",
                Price = 129.99m,
                ImageUrl = "images/products/helmet.jpg",
                Category = "Gear"
            },
            new Product
            {
                Id = 3,
                Name = "Alpine AlpinePack Backpack",
                Description = "Durable backpack for hiking and mountaineering",
                Price = 129.00m,
                ImageUrl = "images/products/backpack.jpg",
                Category = "Bags"
            },
            new Product
            {
                Id = 4,
                Name = "Alpine Fusion Goggles",
                Description = "High-performance goggles for winter sports",
                Price = 79.99m,
                ImageUrl = "images/products/goggles.jpg",
                Category = "Accessories"
            },
            new Product
            {
                Id = 5,
                Name = "Alpine Peak Down Jacket",
                Description = "Premium down jacket for extreme cold conditions",
                Price = 249.99m,
                ImageUrl = "images/products/jacket.jpg",
                Category = "Clothing"
            },
            new Product
            {
                Id = 6,
                Name = "Alpine Tech Crampons",
                Description = "Professional-grade crampons for ice climbing",
                Price = 149.00m,
                ImageUrl = "images/products/crampons.jpg",
                Category = "Gear"
            }
        };

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return Task.FromResult(_products.AsEnumerable());
        }

        public Task<Product?> GetProductByIdAsync(int id)
        {
            return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }
    }
}