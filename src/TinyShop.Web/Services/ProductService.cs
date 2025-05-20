using TinyShop.Web.Models;

namespace TinyShop.Web.Services
{
    public class ProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            // Initialize with sample products based on the image
            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Adventurer GPS Watch",
                    Price = 199.99m,
                    ImageUrl = "/images/products/placeholder.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "AeroLite Cycling Helmet",
                    Price = 129.99m,
                    ImageUrl = "/images/products/placeholder.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Alpine AlpinePack Backpack",
                    Price = 129.00m,
                    ImageUrl = "/images/products/placeholder.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "Alpine Fusion Goggles",
                    Price = 79.99m,
                    ImageUrl = "/images/products/placeholder.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "Alpine Peak Down Jacket",
                    Price = 249.99m,
                    ImageUrl = "/images/products/placeholder.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name = "Alpine Tech Crampons",
                    Price = 149.00m,
                    ImageUrl = "/images/products/placeholder.jpg"
                }
            };
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Product? GetProduct(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}