using Microsoft.EntityFrameworkCore;
using Products.DataEntities;

namespace Products.Data;

public class ProductDataContext : DbContext
{
    public ProductDataContext(DbContextOptions<ProductDataContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Wishlist> Wishlists { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure unique constraint for wishlists to prevent duplicates
        modelBuilder.Entity<Wishlist>()
            .HasIndex(w => new { w.UserId, w.ProductId })
            .IsUnique();

        // Configure the relationship between Wishlist and Product
        modelBuilder.Entity<Wishlist>()
            .HasOne(w => w.Product)
            .WithMany()
            .HasForeignKey(w => w.ProductId);

        // Seed some data
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Product 1",
                Description = "Description for product 1",
                Price = 19.99m,
                ImageUrl = "/images/product1.jpg",
                Category = "Electronics"
            },
            new Product
            {
                Id = 2,
                Name = "Product 2",
                Description = "Description for product 2",
                Price = 29.99m,
                ImageUrl = "/images/product2.jpg",
                Category = "Clothing"
            },
            new Product
            {
                Id = 3,
                Name = "Product 3",
                Description = "Description for product 3",
                Price = 39.99m,
                ImageUrl = "/images/product3.jpg",
                Category = "Home"
            }
        );
    }
}