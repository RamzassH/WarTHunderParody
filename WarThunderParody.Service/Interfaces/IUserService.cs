using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.UserRole;

namespace WarThunderParody.Service.Interfaces;

public interface IUserService
{
    Task<IBaseResponse<IEnumerable<UserRole>>> GetUserRoles();
    
    Task<IBaseResponse<bool>> DeleteUserRole(int id);
    
    Task<IBaseResponse<UserRoleViewModel>> Create(UserRoleViewModel UserRoleViewModel);
    
    Task<IBaseResponse<UserRole>> GetUserRole(int id);

    Task<IBaseResponse<UserRole>> Edit(int id, UserRoleViewModel UserRoleViewModel);
}