using System.Security.Claims;
using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Auth;
using WarThunderParody.Domain.ViewModel.UserAccount;


namespace WarThunderParody.Service.Interfaces;

public interface IAccountService
{
    Task<BaseResponse<bool>> Register(RegisterDBO model);

    Task<BaseResponse<Account>> Login(LoginDBO model);
    
    Task<IBaseResponse<Account>> Edit(int id, UserAccountDBO model);

}