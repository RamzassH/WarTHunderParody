using System.Security.Claims;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Registration;

namespace WarThunderParody.Service.Interfaces;

public interface IAccountService
{
    Task<BaseResponse<ClaimsIdentity>> Register(RegistrationViewModel model);
    
}