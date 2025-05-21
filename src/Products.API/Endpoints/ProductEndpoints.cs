using DataEntities;
using Products.API.Services;

namespace Products.API.Endpoints;

public static class ProductEndpointsExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        // Product endpoints
        app.MapGet("/api/products", (ProductService productService) => 
        {
            return Results.Ok(productService.GetProducts());
        })
        .WithName("GetProducts")
        .WithOpenApi();
        
        app.MapGet("/api/products/{id}", (int id, ProductService productService) =>
        {
            var product = productService.GetProductById(id);
            if (product == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(product);
        })
        .WithName("GetProductById")
        .WithOpenApi();
        
        // Wishlist endpoints
        app.MapGet("/api/wishlist", (HttpContext context, WishlistService wishlistService) =>
        {
            var sessionId = GetOrCreateSessionId(context);
            return Results.Ok(wishlistService.GetWishlistItems(sessionId));
        })
        .WithName("GetWishlist")
        .WithOpenApi();
        
        app.MapPost("/api/wishlist", (HttpContext context, AddToWishlistRequest request, WishlistService wishlistService) =>
        {
            var sessionId = GetOrCreateSessionId(context);
            var wishlistItem = wishlistService.AddToWishlist(sessionId, request.ProductId);
            
            if (wishlistItem == null)
            {
                return Results.NotFound("Product not found");
            }
            
            return Results.Created($"/api/wishlist/{wishlistItem.Id}", wishlistItem);
        })
        .WithName("AddToWishlist")
        .WithOpenApi();
        
        app.MapDelete("/api/wishlist/{id}", (HttpContext context, int id, WishlistService wishlistService) =>
        {
            var sessionId = GetOrCreateSessionId(context);
            var result = wishlistService.RemoveFromWishlist(sessionId, id);
            
            if (!result)
            {
                return Results.NotFound("Wishlist item not found");
            }
            
            return Results.NoContent();
        })
        .WithName("RemoveFromWishlist")
        .WithOpenApi();
    }
    
    private static string GetOrCreateSessionId(HttpContext context)
    {
        const string SessionIdKey = "SessionId";
        
        if (!context.Request.Headers.TryGetValue(SessionIdKey, out var sessionId) || string.IsNullOrEmpty(sessionId))
        {
            // Create new session ID
            sessionId = Guid.NewGuid().ToString();
            context.Response.Headers[SessionIdKey] = sessionId;
        }
        
        return sessionId;
    }
}

// Request DTOs
public record AddToWishlistRequest(int ProductId);