using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.ViewModel.Category;
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
