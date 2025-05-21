using System.Net.Http.Json;
using DataEntities;
using Microsoft.AspNetCore.Components;

namespace Store.Services;

public class WishlistService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly NavigationManager _navigationManager;
    private string _sessionId;

    public WishlistService(
        ProductService productService, 
        IHttpContextAccessor httpContextAccessor,
        NavigationManager navigationManager)
    {
        _httpClient = productService.GetType().GetField("_httpClient", 
                      System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?
                      .GetValue(productService) as HttpClient ?? new HttpClient();
        _httpContextAccessor = httpContextAccessor;
        _navigationManager = navigationManager;
        
        // Get or create session ID
        _sessionId = GetOrCreateSessionId();
    }
    
    public async Task<List<WishlistItem>> GetWishlistItemsAsync()
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, "api/wishlist");
            request.Headers.Add("SessionId", _sessionId);
            
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            
            return await response.Content.ReadFromJsonAsync<List<WishlistItem>>() ?? new List<WishlistItem>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error getting wishlist: {ex.Message}");
            return new List<WishlistItem>();
        }
    }
    
    public async Task<WishlistItem?> AddToWishlistAsync(int productId)
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, "api/wishlist");
            request.Headers.Add("SessionId", _sessionId);
            request.Content = JsonContent.Create(new { ProductId = productId });
            
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            
            return await response.Content.ReadFromJsonAsync<WishlistItem>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error adding to wishlist: {ex.Message}");
            return null;
        }
    }
    
    public async Task<bool> RemoveFromWishlistAsync(int wishlistItemId)
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, $"api/wishlist/{wishlistItemId}");
            request.Headers.Add("SessionId", _sessionId);
            
            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error removing from wishlist: {ex.Message}");
            return false;
        }
    }
    
    private string GetOrCreateSessionId()
    {
        const string SessionIdKey = "SessionId";
        
        if (_httpContextAccessor.HttpContext == null)
        {
            return Guid.NewGuid().ToString();
        }
        
        var sessionId = _httpContextAccessor.HttpContext.Session.GetString(SessionIdKey);
        
        if (string.IsNullOrEmpty(sessionId))
        {
            sessionId = Guid.NewGuid().ToString();
            _httpContextAccessor.HttpContext.Session.SetString(SessionIdKey, sessionId);
        }
        
        return sessionId;
    }
    
    public void NavigateToWishlist()
    {
        _navigationManager.NavigateTo("/wishlist");
    }
}