using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.Controllers;

[ApiController]
[Route("[controller]")]
public class GetNationsController : ControllerBase
{
    private readonly IBaseRepository<Nation> _nationRepository;
    
    public GetNationsController(IBaseRepository<Nation> nationRepository)
    {
        _nationRepository = nationRepository;
    }

    [HttpGet(Name = "GetNations")]
    public async Task<List<Nation>> Get()
    {
        return await _nationRepository.GetAll().ToListAsync();
    }
}