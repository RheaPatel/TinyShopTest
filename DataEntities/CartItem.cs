namespace TinyShop.DataEntities;

/// <summary>
/// Represents an item in the shopping cart.
/// </summary>
public class CartItem
{
    /// <summary>
    /// Gets or sets the product in the cart.
    /// </summary>
    public Product Product { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the quantity of the product in the cart.
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Gets the total price for this cart item (Price * Quantity).
    /// </summary>
    public decimal TotalPrice => Product.Price * Quantity;
}