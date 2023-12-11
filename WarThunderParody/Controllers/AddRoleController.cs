using Microsoft.AspNetCore.Mvc;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.Controllers;

[ApiController]
[Route("[controller]")]
public class AddRoleController : ControllerBase
{
    private readonly IBaseRepository<Roles> _rolesRepository;
    
    public AddRoleController(IBaseRepository<Roles> rolesRepository)
    {
        _rolesRepository = rolesRepository;
    }

    [HttpPost(Name = "AddRoles")]
    public async Task<bool> Get()
    {
        Roles role = new Roles()
        {
            name = "User"
        };
        return await _rolesRepository.Create(role);
    }
}