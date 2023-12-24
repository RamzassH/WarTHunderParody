using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    
    [EnableCors("AllowAllMethods")]
    [HttpGet("GetCategories")]
    [Authorize]
    public async Task<IEnumerable<Category>> Get()
    {
        var response = await _categoryService.GetCategories();
        
        Response.Headers.Add("Total-Count-Categories", response.Data.Count().ToString());
        
        return (List<Category>)response.Data;
    }
    
}
