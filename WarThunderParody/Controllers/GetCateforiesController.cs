using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.Controllers;

[ApiController]
[Route("[controller]")]
public class GetCategoriesController : ControllerBase
{
    private readonly IBaseRepository<Category> _categoryRepository;
    
    public GetCategoriesController(IBaseRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet(Name = "GetCategories")]
    public async Task<List<Category>> Get()
    {
        return await _categoryRepository.GetAll().ToListAsync();
    }
}
