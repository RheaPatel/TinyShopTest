namespace TinyShop.Shared.Models;

public class CartItem
{
    public int Id { get; set; } // Same as Product.Id
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int Quantity { get; set; }
    
    public decimal Total => Price * Quantity;
    
    // Helper method to create a CartItem from a Product
    public static CartItem FromProduct(Product product, int quantity = 1)
    {
        return new CartItem
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            Quantity = quantity
        };
    }
}