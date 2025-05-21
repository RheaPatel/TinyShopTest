using DataEntities;

namespace Products.API.Services;

public class WishlistService
{
    private readonly Dictionary<string, List<WishlistItem>> _wishlistItems = new();
    private readonly ProductService _productService;
    private int _nextId = 1;
    
    public WishlistService(ProductService productService)
    {
        _productService = productService;
    }
    
    public IEnumerable<WishlistItem> GetWishlistItems(string sessionId)
    {
        if (_wishlistItems.TryGetValue(sessionId, out var items))
        {
            return items;
        }
        
        return Enumerable.Empty<WishlistItem>();
    }
    
    public WishlistItem? AddToWishlist(string sessionId, int productId)
    {
        var product = _productService.GetProductById(productId);
        if (product == null)
        {
            return null;
        }
        
        if (!_wishlistItems.TryGetValue(sessionId, out var items))
        {
            items = new List<WishlistItem>();
            _wishlistItems[sessionId] = items;
        }
        
        // Check if product is already in wishlist
        if (items.Any(item => item.ProductId == productId))
        {
            return items.First(item => item.ProductId == productId);
        }
        
        // Add new item to wishlist
        var wishlistItem = new WishlistItem
        {
            Id = _nextId++,
            SessionId = sessionId,
            ProductId = productId,
            DateAdded = DateTime.UtcNow,
            Product = product
        };
        
        items.Add(wishlistItem);
        
        return wishlistItem;
    }
    
    public bool RemoveFromWishlist(string sessionId, int wishlistItemId)
    {
        if (!_wishlistItems.TryGetValue(sessionId, out var items))
        {
            return false;
        }
        
        var item = items.FirstOrDefault(i => i.Id == wishlistItemId);
        if (item == null)
        {
            return false;
        }
        
        return items.Remove(item);
    }
}