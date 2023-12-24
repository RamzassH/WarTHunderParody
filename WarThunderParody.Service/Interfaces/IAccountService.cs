using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Auth;
using WarThunderParody.Domain.ViewModel.UserAccount;


namespace WarThunderParody.Service.Interfaces;

public interface IAccountService
{
    Task<BaseResponse<bool>> Register(RegisterDTO model);

    Task<BaseResponse<Account>> Login(LoginDTO model);
    
    Task<IBaseResponse<Account>> Edit(int id, UserAccountDTO model);

    Task<IBaseResponse<UserAccountDTO>> GetAccountInfoByEmail(string email);

}