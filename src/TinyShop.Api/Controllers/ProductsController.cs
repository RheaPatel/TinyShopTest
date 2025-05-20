using Microsoft.AspNetCore.Mvc;
using TinyShop.Api.Models;
using TinyShop.Api.Services;

namespace TinyShop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(_productService.GetAllProducts());
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _productService.GetProductById(id);
        
        if (product == null)
        {
            return NotFound();
        }
        
        return Ok(product);
    }
}