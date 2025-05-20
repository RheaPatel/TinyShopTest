using System.Text.Json;
using Microsoft.JSInterop;
using TinyShop.Shared.Models;

namespace TinyShop.Web.Services;

public class CartService
{
    private readonly IJSRuntime _jsRuntime;
    private const string CART_STORAGE_KEY = "tinyshop_cart";
    private List<CartItem> _cart = new();
    
    public event Action? OnCartChanged;
    
    public CartService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    public async Task<List<CartItem>> GetCartItemsAsync()
    {
        if (_cart.Count == 0)
        {
            await LoadCartFromStorageAsync();
        }
        
        return _cart;
    }
    
    public async Task AddToCartAsync(Product product, int quantity = 1)
    {
        var existingItem = _cart.FirstOrDefault(item => item.Id == product.Id);
        
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            _cart.Add(CartItem.FromProduct(product, quantity));
        }
        
        await SaveCartToStorageAsync();
        OnCartChanged?.Invoke();
    }
    
    public async Task UpdateQuantityAsync(int productId, int quantity)
    {
        var item = _cart.FirstOrDefault(item => item.Id == productId);
        
        if (item != null)
        {
            if (quantity <= 0)
            {
                _cart.Remove(item);
            }
            else
            {
                item.Quantity = quantity;
            }
            
            await SaveCartToStorageAsync();
            OnCartChanged?.Invoke();
        }
    }
    
    public async Task RemoveFromCartAsync(int productId)
    {
        var item = _cart.FirstOrDefault(item => item.Id == productId);
        
        if (item != null)
        {
            _cart.Remove(item);
            await SaveCartToStorageAsync();
            OnCartChanged?.Invoke();
        }
    }
    
    public async Task ClearCartAsync()
    {
        _cart.Clear();
        await SaveCartToStorageAsync();
        OnCartChanged?.Invoke();
    }
    
    public int GetCartItemCount()
    {
        return _cart.Sum(item => item.Quantity);
    }
    
    public decimal GetCartTotal()
    {
        return _cart.Sum(item => item.Total);
    }
    
    private async Task LoadCartFromStorageAsync()
    {
        try
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", CART_STORAGE_KEY);
            
            if (!string.IsNullOrEmpty(json))
            {
                _cart = JsonSerializer.Deserialize<List<CartItem>>(json) ?? new List<CartItem>();
            }
        }
        catch
        {
            // If there's an error loading from storage, start with an empty cart
            _cart = new List<CartItem>();
        }
    }
    
    private async Task SaveCartToStorageAsync()
    {
        var json = JsonSerializer.Serialize(_cart);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", CART_STORAGE_KEY, json);
    }
}