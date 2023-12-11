using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Helpers;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Registration;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class AccountService : IAccountService
{
    private readonly IBaseRepository<UserAccount> _userAccountRepository;
    private readonly ILogger<AccountService> _logger;

    public AccountService(IBaseRepository<UserAccount> userRepository,
        ILogger<AccountService> logger)
    {
        _userAccountRepository = userRepository;
        _logger = logger;
    }

    public async Task<BaseResponse<ClaimsIdentity>> Register(RegistrationViewModel model)
    {
        try
        {
            var user = await _userAccountRepository.GetAll().FirstOrDefaultAsync(x => x.name == model.Name);
            if (user != null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь с таким логином уже есть",
                };
            }

            user = new UserAccount()
            {
                name = model.Name,
                email = model.email,
                registration_date = DateTime.Today,
                ballance = 0,
                role = new Roles()
                {
                    name = "User"
                },
                password = HashPasswordHelper.HashPassword(model.Password),
            };

            await _userAccountRepository.Create(user);

            var result = Authenticate(user);

            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                Description = "Объект добавился",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[Register]: {ex.Message}");
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    private ClaimsIdentity Authenticate(UserAccount user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.name),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.role.ToString())
        };
        return new ClaimsIdentity(claims, "ApplicationCookie",
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
    }
}