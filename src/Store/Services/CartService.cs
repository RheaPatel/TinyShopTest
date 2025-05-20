using Store.Models;

namespace Store.Services;

public class CartService
{
    private readonly List<CartItem> _cartItems = new();
    
    public event Action? OnChange;
    
    public List<CartItem> GetCartItems()
    {
        return _cartItems;
    }
    
    public void AddToCart(Product product)
    {
        var existingItem = _cartItems.FirstOrDefault(item => item.ProductId == product.Id);
        
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            _cartItems.Add(new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1,
                ImageUrl = product.ImageUrl
            });
        }
        
        OnChange?.Invoke();
    }
    
    public void RemoveFromCart(int productId)
    {
        var item = _cartItems.FirstOrDefault(item => item.ProductId == productId);
        
        if (item != null)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                _cartItems.Remove(item);
            }
            
            OnChange?.Invoke();
        }
    }
    
    public int GetCartItemsCount()
    {
        return _cartItems.Sum(item => item.Quantity);
    }
    
    public decimal GetCartTotal()
    {
        return _cartItems.Sum(item => item.Total);
    }
    
    public void ClearCart()
    {
        _cartItems.Clear();
        OnChange?.Invoke();
    }
}