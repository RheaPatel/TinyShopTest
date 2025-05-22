using DataEntities;

namespace Store.Services;

/// <summary>
/// Service to manage the shopping cart state
/// </summary>
public class CartService
{
    private List<CartItem> _cartItems = new();
    
    /// <summary>
    /// Event that fires when the cart changes
    /// </summary>
    public event Action? OnChange;
    
    /// <summary>
    /// Add a product to the cart
    /// </summary>
    /// <param name="product">The product to add</param>
    public void AddToCart(Product product)
    {
        // Check if the product is already in the cart
        var existingItem = _cartItems.FirstOrDefault(item => item.Product.Id == product.Id);
        
        if (existingItem != null)
        {
            // If the product is already in the cart, increment the quantity
            existingItem.Quantity++;
        }
        else
        {
            // Otherwise, add a new cart item
            _cartItems.Add(new CartItem
            {
                Product = product,
                Quantity = 1
            });
        }
        
        NotifyStateChanged();
    }
    
    /// <summary>
    /// Remove a product from the cart
    /// </summary>
    /// <param name="productId">The ID of the product to remove</param>
    public void RemoveFromCart(int productId)
    {
        var itemToRemove = _cartItems.FirstOrDefault(item => item.Product.Id == productId);
        
        if (itemToRemove != null)
        {
            _cartItems.Remove(itemToRemove);
            NotifyStateChanged();
        }
    }
    
    /// <summary>
    /// Update the quantity of a product in the cart
    /// </summary>
    /// <param name="productId">The ID of the product to update</param>
    /// <param name="quantity">The new quantity</param>
    public void UpdateQuantity(int productId, int quantity)
    {
        var item = _cartItems.FirstOrDefault(item => item.Product.Id == productId);
        
        if (item != null)
        {
            if (quantity <= 0)
            {
                _cartItems.Remove(item);
            }
            else
            {
                item.Quantity = quantity;
            }
            
            NotifyStateChanged();
        }
    }
    
    /// <summary>
    /// Get all items in the cart
    /// </summary>
    /// <returns>The list of cart items</returns>
    public IReadOnlyList<CartItem> GetCartItems() => _cartItems.AsReadOnly();
    
    /// <summary>
    /// Calculate the total cost of the items in the cart
    /// </summary>
    /// <returns>The total cost</returns>
    public decimal GetTotalCost() => _cartItems.Sum(item => item.Product.Price * item.Quantity);
    
    /// <summary>
    /// Get the total number of items in the cart
    /// </summary>
    /// <returns>The total item count</returns>
    public int GetTotalItemCount() => _cartItems.Sum(item => item.Quantity);
    
    /// <summary>
    /// Clear all items from the cart
    /// </summary>
    public void ClearCart()
    {
        _cartItems.Clear();
        NotifyStateChanged();
    }
    
    /// <summary>
    /// Notify components that the cart state has changed
    /// </summary>
    private void NotifyStateChanged() => OnChange?.Invoke();
}