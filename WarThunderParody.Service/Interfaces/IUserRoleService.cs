using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.UserAccount;

namespace WarThunderParody.Service.Interfaces;

public interface IUserRoleService
{
    Task<IBaseResponse<IEnumerable<Account>>> GetUserAccounts();
    
    Task<IBaseResponse<bool>> DeleteUserAccount(int id);
    
    Task<IBaseResponse<UserAccountDBO>> Create(UserAccountDBO userAccountDbo);
    
    Task<IBaseResponse<Account>> GetUserAccount(int id);

    Task<IBaseResponse<Account>> Edit(int id, UserAccountDBO userAccountDbo);
}