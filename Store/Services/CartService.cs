using TinyShop.DataEntities;

namespace TinyShop.Store.Services;

/// <summary>
/// Service to manage the shopping cart in the TinyShop application.
/// </summary>
public class CartService
{
    private readonly List<CartItem> _cartItems = new();
    
    /// <summary>
    /// Event raised when the cart changes.
    /// </summary>
    public event Action? OnCartChanged;
    
    /// <summary>
    /// Gets the current cart items.
    /// </summary>
    /// <returns>The list of cart items.</returns>
    public List<CartItem> GetCartItems()
    {
        return _cartItems;
    }
    
    /// <summary>
    /// Adds a product to the cart.
    /// </summary>
    /// <param name="product">The product to add.</param>
    /// <param name="quantity">The quantity to add (default: 1).</param>
    public void AddToCart(Product product, int quantity = 1)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));
            
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            
        var existingItem = _cartItems.FirstOrDefault(item => item.Product.Id == product.Id);
        
        if (existingItem != null)
        {
            // Product already in cart, update quantity
            existingItem.Quantity += quantity;
        }
        else
        {
            // Add new item to cart
            _cartItems.Add(new CartItem
            {
                Product = product,
                Quantity = quantity
            });
        }
        
        OnCartChanged?.Invoke();
    }
    
    /// <summary>
    /// Removes an item from the cart.
    /// </summary>
    /// <param name="productId">The ID of the product to remove.</param>
    public void RemoveFromCart(int productId)
    {
        var item = _cartItems.FirstOrDefault(item => item.Product.Id == productId);
        if (item != null)
        {
            _cartItems.Remove(item);
            OnCartChanged?.Invoke();
        }
    }
    
    /// <summary>
    /// Updates the quantity of an item in the cart.
    /// </summary>
    /// <param name="productId">The ID of the product to update.</param>
    /// <param name="quantity">The new quantity.</param>
    public void UpdateQuantity(int productId, int quantity)
    {
        if (quantity <= 0)
        {
            RemoveFromCart(productId);
            return;
        }
        
        var item = _cartItems.FirstOrDefault(item => item.Product.Id == productId);
        if (item != null)
        {
            item.Quantity = quantity;
            OnCartChanged?.Invoke();
        }
    }
    
    /// <summary>
    /// Clears all items from the cart.
    /// </summary>
    public void ClearCart()
    {
        _cartItems.Clear();
        OnCartChanged?.Invoke();
    }
    
    /// <summary>
    /// Gets the total number of items in the cart.
    /// </summary>
    /// <returns>The total number of items.</returns>
    public int GetTotalItems()
    {
        return _cartItems.Sum(item => item.Quantity);
    }
    
    /// <summary>
    /// Gets the total price of all items in the cart.
    /// </summary>
    /// <returns>The total price.</returns>
    public decimal GetTotalPrice()
    {
        return _cartItems.Sum(item => item.TotalPrice);
    }
}