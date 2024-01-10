using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WarThunderParody.Domain.ViewModel.Category;
using WarThunderParody.Domain.ViewModel.Product;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [EnableCors("AllowAllMethods")]
    [Microsoft.AspNetCore.Mvc.HttpGet("GetPremiumAccounts")]
    public async Task<List<ProductDTO>> GetProductPremiumAccounts([FromQuery] GetProductDTO model)
    {
        var products = await _productService.GetPremiumAccountsByPage(model.Limit, model.Page);
        Response.Headers.Add("Total-Count-Categories", products.Data.Count().ToString());
        return products.Data;
    }

    [EnableCors("AllowAllMethods")]
    [Microsoft.AspNetCore.Mvc.HttpGet("GetPremiumCurrency")]
    public async Task<IEnumerable<ProductDTO>> GetProductPremiumCurrency([FromQuery] GetProductDTO model)
    {
        var products = await _productService.GetPremiumCurrencyByPage(model.Limit, model.Page); 
        Response.Headers.Add("Total-Count-Categories", products.Data.Count().ToString());
        return products.Data;
    }

    [EnableCors("AllowAllMethods")]
    [Microsoft.AspNetCore.Mvc.HttpGet("GetTechnique")]
    public async Task<IEnumerable<ProductDTO>> GetTechnique([FromQuery] GetTechniqueDTO model)
    { 
        var products = await _productService.GetTechnique(model.Limit, model.Page,
            model.CategoriesId, model.NationsId);
        
        Response.Headers.Add("Total-Count-Products", products.Data.Count().ToString());
        return products.Data;
    }
    
    [EnableCors("AllowAllMethods")]
    [Microsoft.AspNetCore.Mvc.HttpGet("GetAllProducts")]
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        var products = await _productService.GetProducts();
        Response.Headers.Add("Total-Count-Products", products.Data.Count().ToString());
        return products.Data;
    }

    [Microsoft.AspNetCore.Mvc.HttpPost("CreateProduct")]        
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateProduct([Microsoft.AspNetCore.Mvc.FromBody] CreateProductDTO model)
    {
        var result = await _productService.CreateProduct(model);
        
        if (result.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return BadRequest("Invalid login attempt.");
        }
    
        return Ok(result.StatusCode);
    }
    
    
    [EnableCors("AllowAllMethods")]
    [Microsoft.AspNetCore.Mvc.HttpGet("GetProduct")]
    public async Task<ProductDTO> GetProduct([FromQuery] int id)
    {
        HttpContext.Response.Headers.Add("ngrok-skip-browser-warning", "true");
        var products = await _productService.GetProduct(id);
        
        return products.Data;
    }

}