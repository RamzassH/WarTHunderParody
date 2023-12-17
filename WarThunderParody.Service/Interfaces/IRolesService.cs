using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Roles;

namespace WarThunderParody.Service.Interfaces;

public interface IRolesService
{
    Task<IBaseResponse<IEnumerable<Role>>> GetRoles();
    
    Task<IBaseResponse<bool>> DeleteRole(int id);
    
    Task<IBaseResponse<bool>> Create(RolesDTO model);

    Task<IBaseResponse<IEnumerable<Role>>> GetUserRolesByUserId(int id);

    Task<IBaseResponse<Account>> MakeUserAdmin(string email);
    
    Task<IBaseResponse<Role>> GetRole(int id);

    Task<IBaseResponse<Role>> Edit(int id, RolesDTO model);
}