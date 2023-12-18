using Microsoft.AspNetCore.Mvc;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;

[ApiController]
[Route("[controller]")]
public class NationsController : ControllerBase
{
    private readonly INationService _nationService;
    
    public NationsController(INationService nationService)
    {
        _nationService = nationService;
    }

    [HttpGet("GetNations")]
    public async Task<List<Nation>> Get()
    {
        var response = await _nationService.GetNations();
        return (List<Nation>)response.Data;
    }
}