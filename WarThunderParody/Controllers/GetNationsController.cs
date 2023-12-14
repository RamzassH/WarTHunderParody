using Microsoft.AspNetCore.Mvc;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;

[ApiController]
[Route("[controller]")]
public class GetNationsController : ControllerBase
{
    private readonly INationService _nationService;
    
    public GetNationsController(INationService nationService)
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