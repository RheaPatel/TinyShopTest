namespace Products.DataEntities;

public class Wishlist
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
}