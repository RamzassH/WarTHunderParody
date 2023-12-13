using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Roles;

namespace WarThunderParody.Service.Interfaces;

public interface IRolesService
{
    Task<IBaseResponse<IEnumerable<Role>>> GetRoles();
    
    Task<IBaseResponse<bool>> DeleteRole(int id);
    
    Task<IBaseResponse<RolesDBO>> Create(RolesDBO orderDbo);
    
    Task<IBaseResponse<Role>> GetRole(int id);

    Task<IBaseResponse<Role>> Edit(int id, RolesDBO orderDbo);
}