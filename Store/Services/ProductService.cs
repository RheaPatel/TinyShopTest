using System.Collections.Generic;
using System.Threading.Tasks;
using TinyShop.DataEntities;

namespace TinyShop.Store.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product
            {
                Id = 1,
                Name = "Stylish Watch",
                Description = "Elegant watch with leather strap",
                Price = 99.99m,
                ImageUrl = "/images/products/watch.jpg",
                Category = "Accessories",
                InStock = true
            },
            new Product
            {
                Id = 2,
                Name = "Bluetooth Headphones",
                Description = "Noise-cancelling wireless headphones",
                Price = 149.99m,
                ImageUrl = "/images/products/headphones.jpg",
                Category = "Electronics",
                InStock = true
            },
            new Product
            {
                Id = 3,
                Name = "Smart Speaker",
                Description = "Voice-controlled smart home speaker",
                Price = 79.99m,
                ImageUrl = "/images/products/speaker.jpg",
                Category = "Electronics",
                InStock = true
            },
            new Product
            {
                Id = 4,
                Name = "Coffee Mug",
                Description = "Ceramic mug with minimalist design",
                Price = 14.99m,
                ImageUrl = "/images/products/mug.jpg",
                Category = "Home",
                InStock = true
            }
        };

        public Task<List<Product>> GetProductsAsync()
        {
            return Task.FromResult(new List<Product>(_products));
        }

        public Task<Product?> GetProductByIdAsync(int id)
        {
            var product = _products.Find(p => p.Id == id);
            return Task.FromResult(product);
        }
    }
}