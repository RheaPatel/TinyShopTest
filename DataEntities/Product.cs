namespace DataEntities;

/// <summary>
/// Represents a product in the store
/// </summary>
public class Product
{
    /// <summary>
    /// Unique identifier for the product
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Name of the product
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Description of the product
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Price of the product
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// URL to the product image
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;
    
    /// <summary>
    /// Category of the product
    /// </summary>
    public string Category { get; set; } = string.Empty;
    
    /// <summary>
    /// Whether the product is available for purchase
    /// </summary>
    public bool IsAvailable { get; set; } = true;
}