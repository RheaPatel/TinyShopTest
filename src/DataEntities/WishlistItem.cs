namespace DataEntities;

public class WishlistItem
{
    public int Id { get; set; }
    public string SessionId { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    
    // Navigation property
    public Product? Product { get; set; }
}