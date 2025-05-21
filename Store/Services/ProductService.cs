using System.Net.Http.Json;
using Products.DataEntities;

namespace Store.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly string _apiBaseUrl;

    public ProductService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _apiBaseUrl = configuration["ApiBaseUrl"] ?? "https://localhost:5001";
    }

    // Products
    public async Task<List<Product>> GetProductsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Product>>($"{_apiBaseUrl}/api/products") ?? new List<Product>();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Product>($"{_apiBaseUrl}/api/products/{id}");
    }

    // Wishlist
    public async Task<List<Wishlist>> GetWishlistAsync(string userId)
    {
        return await _httpClient.GetFromJsonAsync<List<Wishlist>>($"{_apiBaseUrl}/api/products/wishlist/{userId}") ?? new List<Wishlist>();
    }

    public async Task<bool> AddToWishlistAsync(string userId, int productId)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/api/products/wishlist", new { UserId = userId, ProductId = productId });
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveFromWishlistAsync(string userId, int productId)
    {
        var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/api/products/wishlist/{userId}/{productId}");
        return response.IsSuccessStatusCode;
    }
}