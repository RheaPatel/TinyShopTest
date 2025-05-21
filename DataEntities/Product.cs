namespace TinyShop.DataEntities;

/// <summary>
/// Represents a product in the TinyShop application.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Gets or sets the image file name of the product.
    /// </summary>
    public string? ImageFileName { get; set; }
    
    /// <summary>
    /// Gets or sets the category of the product.
    /// </summary>
    public string? Category { get; set; }
    
    /// <summary>
    /// Gets or sets whether the product is in stock.
    /// </summary>
    public bool InStock { get; set; } = true;
    
    /// <summary>
    /// Gets or sets the quantity available in stock.
    /// </summary>
    public int StockQuantity { get; set; }
}