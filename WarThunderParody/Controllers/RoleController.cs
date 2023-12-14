using Microsoft.AspNetCore.Mvc;
using WarThunderParody.Domain.ViewModel.Roles;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRolesService _rolesService;

    public RoleController(IRolesService rolesService)
    {
        _rolesService = rolesService;
    }
    
    [HttpGet("GetRoles")]
    public async Task<IEnumerable<Role>> GetRoles()
    {
        var response = await _rolesService.GetRoles();

        return response.Data;
    }
    
    [HttpPost("AddRole")]
    public async Task<IActionResult> AddRole([FromBody] RolesDBO model)
    {
        var response = await _rolesService.Create(model);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Ok();
        }

        return BadRequest(response.Description);
    }
    
    [HttpPost( "DeleteRole")]
    public async Task<IActionResult> DeleteRole([FromBody] RolesDBO model)
    {
        var response = await _rolesService.DeleteRole(model.Id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Ok();
        }
    
        return BadRequest(response.Description);
    }
}