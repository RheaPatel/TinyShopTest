using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.DataEntities;

namespace Products.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/products").WithTags("Products");

        group.MapGet("/", async (ProductDataContext db) =>
        {
            return await db.Products.ToListAsync();
        })
        .WithName("GetAllProducts")
        .WithOpenApi();

        group.MapGet("/{id}", async (int id, ProductDataContext db) =>
        {
            return await db.Products.FindAsync(id)
                is Product product
                ? Results.Ok(product)
                : Results.NotFound();
        })
        .WithName("GetProductById")
        .WithOpenApi();

        // Wishlist endpoints

        group.MapGet("/wishlist/{userId}", async (string userId, ProductDataContext db) =>
        {
            var wishlistItems = await db.Wishlists
                .Where(w => w.UserId == userId)
                .Include(w => w.Product)
                .ToListAsync();

            return Results.Ok(wishlistItems);
        })
        .WithName("GetWishlist")
        .WithOpenApi();

        group.MapPost("/wishlist", async (AddWishlistRequest request, ProductDataContext db) =>
        {
            var product = await db.Products.FindAsync(request.ProductId);
            if (product == null)
                return Results.NotFound("Product not found");

            var existingItem = await db.Wishlists
                .FirstOrDefaultAsync(w => w.UserId == request.UserId && w.ProductId == request.ProductId);

            if (existingItem != null)
                return Results.Conflict("Product already in wishlist");

            var wishlistItem = new Wishlist
            {
                UserId = request.UserId,
                ProductId = request.ProductId
            };

            db.Wishlists.Add(wishlistItem);
            await db.SaveChangesAsync();

            return Results.Created($"/api/products/wishlist/{request.UserId}", wishlistItem);
        })
        .WithName("AddToWishlist")
        .WithOpenApi();

        group.MapDelete("/wishlist/{userId}/{productId}", async (string userId, int productId, ProductDataContext db) =>
        {
            var wishlistItem = await db.Wishlists
                .FirstOrDefaultAsync(w => w.UserId == userId && w.ProductId == productId);

            if (wishlistItem == null)
                return Results.NotFound("Wishlist item not found");

            db.Wishlists.Remove(wishlistItem);
            await db.SaveChangesAsync();

            return Results.Ok();
        })
        .WithName("RemoveFromWishlist")
        .WithOpenApi();
    }
}

// Request models
public record AddWishlistRequest(string UserId, int ProductId);