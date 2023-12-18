using System.Web.Http;
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

    [Microsoft.AspNetCore.Mvc.HttpPost("GetPremiumAccounts")]
    public async Task<List<ProductDTO>> GetProductPremiumAccounts([Microsoft.AspNetCore.Mvc.FromBody] GetProductDTO model)
    {
        var products = await _productService.GetPremiumAccountsByPage(model.Limit, model.Page);
        Response.Headers.Add("Total-Count-Categories", products.Data.Count().ToString());
        return products.Data;
    }

    [Microsoft.AspNetCore.Mvc.HttpPost("GetPremiumCurrency")]
    public async Task<IEnumerable<ProductDTO>> GetProductPremiumCurrency([Microsoft.AspNetCore.Mvc.FromBody] GetProductDTO model)
    {
        var products = await _productService.GetPremiumCurrencyByPage(model.Limit, model.Page); 
        Response.Headers.Add("Total-Count-Categories", products.Data.Count().ToString());
        return products.Data;
    }

    [Microsoft.AspNetCore.Mvc.HttpPost("GetTechnique")]
    public async Task<IEnumerable<ProductDTO>> GetTechnique([Microsoft.AspNetCore.Mvc.FromBody] GetTechniqueDTO model)
    {
        List<Category> categories = new List<Category>();
        foreach (var category in model.Categories)
        {
            categories.Add(new Category
            {
                Name = category.Name
            });
        }
        List<Nation> nations= new List<Nation>();
        foreach (var nation in model.Nations)
        {
            nations.Add(new Nation
            {
                Name = nation.Name
            });
        }
        var products = await _productService.GetTechnique(model.Limit, model.Page,
            categories, nations);
        
        Response.Headers.Add("Total-Count-Categories", products.Data.Count().ToString());
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