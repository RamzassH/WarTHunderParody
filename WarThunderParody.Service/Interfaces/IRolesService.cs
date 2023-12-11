using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Roles;

namespace WarThunderParody.Service.Interfaces;

public interface IRolesService
{
    Task<IBaseResponse<IEnumerable<Roles>>> GetRoles();
    
    Task<IBaseResponse<bool>> DeleteRole(int id);
    
    Task<IBaseResponse<RolesViewModel>> Create(RolesViewModel orderViewModel);
    
    Task<IBaseResponse<Roles>> GetRole(int id);

    Task<IBaseResponse<Roles>> Edit(int id, RolesViewModel orderViewModel);
}