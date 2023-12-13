using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.UserRole;

namespace WarThunderParody.Service.Interfaces;

public interface IUserService
{
    Task<IBaseResponse<IEnumerable<UserRole>>> GetUserRoles();
    
    Task<IBaseResponse<bool>> DeleteUserRole(int id);
    
    Task<IBaseResponse<UserRoleDBO>> Create(UserRoleDBO userRoleDbo);
    
    Task<IBaseResponse<UserRole>> GetUserRole(int id);

    Task<IBaseResponse<UserRole>> Edit(int id, UserRoleDBO userRoleDbo);
}