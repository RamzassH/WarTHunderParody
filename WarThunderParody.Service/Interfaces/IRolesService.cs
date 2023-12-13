using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Roles;

namespace WarThunderParody.Service.Interfaces;

public interface IRolesService
{
    Task<IBaseResponse<IEnumerable<Role>>> GetRoles();
    
    Task<IBaseResponse<bool>> DeleteRole(int id);
    
    Task<IBaseResponse<bool>> Create(RolesDBO model);

    Task<IBaseResponse<IEnumerable<Role>>> GetUserRolesByUserId(int id);

    Task<IBaseResponse<bool>> MakeUserAdmin(string email);
    
    Task<IBaseResponse<Role>> GetRole(int id);

    Task<IBaseResponse<Role>> Edit(int id, RolesDBO model);
}