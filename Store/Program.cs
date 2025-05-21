using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TinyShop.Products.Endpoints;
using TinyShop.Store.Services;
using Blazored.Toast;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add services
builder.Services.AddSingleton<ProductService>();
builder.Services.AddScoped<CartService>();

// Add Blazored Toast for notifications
builder.Services.AddBlazoredToast();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Register API endpoints
app.MapProductEndpoints();

app.MapRazorComponents<TinyShop.Store.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();