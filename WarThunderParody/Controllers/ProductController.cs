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
        HttpContext.Response.Headers.Add("ngrok-skip-browser-warning", "true");
        //List<Category> categories = new List<Category>();
        // if (model.CategoriesId != null)
        // {
        //     foreach (var category in model.Categories)
        //     {
        //         categories.Add(new Category
        //         {
        //             Name = category.Name
        //         });
        //     }
        // }
        //
        // List<Nation> nations= new List<Nation>();
        // if (model.NationsId != null)
        // {
        //     foreach (var nation in model.Nations)
        //     {
        //         nations.Add(new Nation
        //         {
        //             Name = nation.Name
        //         });
        //     }
        // }
      
        var products = await _productService.GetTechnique(model.Limit, model.Page,
            model.CategoriesId, model.NationsId);
        
        Response.Headers.Add("Total-Count-Products", products.Data.Count().ToString());
        return products.Data;
    }

    [Microsoft.AspNetCore.Mvc.HttpPost("CreateProduct")]
    [Authorize]
    public async Task<IActionResult> CreateProduct([Microsoft.AspNetCore.Mvc.FromBody] ProductDTO model)
    {
        var result = await _productService.CreateProduct(model);
        
        if (result.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return BadRequest("Invalid login attempt.");
        }
    
        return Ok(result.StatusCode);
    }
}