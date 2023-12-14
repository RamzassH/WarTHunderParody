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
    public async Task<List<Category>> Get()
    {
        var response = await _categoryService.GetCategories();
        return (List<Category>)response.Data;
    }
}
