using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.UserAccount;

namespace WarThunderParody.Service.Interfaces;

public interface IUserRoleService
{
    Task<IBaseResponse<IEnumerable<UserAccount>>> GetUserAccounts();
    
    Task<IBaseResponse<bool>> DeleteUserAccount(int id);
    
    Task<IBaseResponse<UserAccountViewModel>> Create(UserAccountViewModel UserAccountViewModel);
    
    Task<IBaseResponse<UserAccount>> GetUserAccount(int id);

    Task<IBaseResponse<UserAccount>> Edit(int id, UserAccountViewModel UserAccountViewModel);
}