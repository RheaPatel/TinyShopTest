using Microsoft.AspNetCore.Mvc;
using TinyShop.DataEntities;

namespace TinyShop.Products.Endpoints;

/// <summary>
/// Extension methods for product API endpoints.
/// </summary>
public static class ProductEndpoints
{
    /// <summary>
    /// Maps product API endpoints to the specified application.
    /// </summary>
    /// <param name="app">The application to map endpoints to.</param>
    /// <returns>The application with mapped endpoints.</returns>
    public static WebApplication MapProductEndpoints(this WebApplication app)
    {
        var productsGroup = app.MapGroup("/api/products");
        
        // Get all products
        productsGroup.MapGet("/", (IConfiguration config) =>
        {
            var productService = new TinyShop.Store.Services.ProductService(config);
            return Results.Ok(productService.GetAllProducts());
        });
        
        // Get product by ID
        productsGroup.MapGet("/{id}", (int id, IConfiguration config) =>
        {
            var productService = new TinyShop.Store.Services.ProductService(config);
            var product = productService.GetProductById(id);
            
            if (product == null)
                return Results.NotFound();
                
            return Results.Ok(product);
        });
        
        // Get products by category
        productsGroup.MapGet("/category/{category}", (string category, IConfiguration config) =>
        {
            var productService = new TinyShop.Store.Services.ProductService(config);
            var products = productService.GetProductsByCategory(category);
            
            return Results.Ok(products);
        });
        
        return app;
    }
}