using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Roles;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class RolesService : IRolesService
{
    public Task<IBaseResponse<IEnumerable<Roles>>> GetRoles()
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<bool>> DeleteRole(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<RolesViewModel>> Create(RolesViewModel orderViewModel)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Roles>> GetRole(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Roles>> Edit(int id, RolesViewModel orderViewModel)
    {
        throw new NotImplementedException();
    }
}