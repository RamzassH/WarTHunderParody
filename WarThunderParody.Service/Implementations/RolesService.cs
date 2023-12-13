using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Roles;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class RolesService : IRolesService
{
    private readonly IBaseRepository<Role> _rolesRepository;

    public RolesService(IBaseRepository<Role> userRepository)
    {
        _rolesRepository = userRepository;
    }

    public async Task<IBaseResponse<IEnumerable<Role>>> GetRoles()
    {
        var response = new BaseResponse<IEnumerable<Role>>();
        try
        {
            var roles = await _rolesRepository.GetAll().ToListAsync();
            if (roles.Count == 0)
            {
                response.Description = "Найдено 0 элементов";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }

            response.Data = roles;
            response.StatusCode = StatusCode.OK;
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Role>>()
            {
                Description = $"[GetRoles] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteRole(int id)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var roles = _rolesRepository.GetAll();
            var roleToDelete = await roles.FirstOrDefaultAsync(x => x.Id == id);

            if (roleToDelete == null)
            {
                response.Description = "Найдено 0 элементов";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }

            response.StatusCode = StatusCode.OK;
            await _rolesRepository.Delete(roleToDelete);
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteRole] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<RolesDBO>> Create(RolesDBO rolesDbo)
    {
        var response = new BaseResponse<RolesDBO>();
        try
        {
            var role = new Role
            {
                Name = rolesDbo.Name
            };
            if (role is null)
            {
                response.Description = "Роль не создана";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }
            await _rolesRepository.Create(role);
            response.StatusCode = StatusCode.OK;

            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<RolesDBO>()
            {
                Description = $"[CreateRole] : {e.Message}"
            };
        }
    }

    public Task<IBaseResponse<Role>> GetRole(int id)
    {
        throw new NotImplementedException();
    }
    public Task<IBaseResponse<Role>> GetRoleByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Role>> Edit(int id, RolesDBO orderDbo)
    {
        throw new NotImplementedException();
    }
}