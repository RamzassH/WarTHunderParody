using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.UserRole;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class UserRoleService : IUserService
{
    public Task<IBaseResponse<IEnumerable<UserRole>>> GetUserRoles()
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<bool>> DeleteUserRole(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<UserRoleDBO>> Create(UserRoleDBO userRoleDbo)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<UserRole>> GetUserRole(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<UserRole>> Edit(int id, UserRoleDBO userRoleDbo)
    {
        throw new NotImplementedException();
    }
}