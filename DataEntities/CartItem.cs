namespace DataEntities;

/// <summary>
/// Represents an item in the shopping cart
/// </summary>
public class CartItem
{
    /// <summary>
    /// The product in the cart
    /// </summary>
    public Product Product { get; set; } = new();
    
    /// <summary>
    /// Quantity of the product in the cart
    /// </summary>
    public int Quantity { get; set; } = 1;
}