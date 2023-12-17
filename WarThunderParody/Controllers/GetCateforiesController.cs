using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;

[ApiController]
[Route("[controller]")]
public class GetCategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    
    public GetCategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet("GetCategories")]
    public async Task<IEnumerable<Category>> Get()
    {
        var response = await _categoryService.GetCategories();
        
        Response.Headers.Add("Total-Count-Categories", response.Data.Count().ToString());
        
        return (List<Category>)response.Data;
    }
}
