using Microsoft.AspNetCore.Mvc;
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
    public List<Category> Get()
    {
        return _categoryRepository.GetAll().ToList();
    }
}
