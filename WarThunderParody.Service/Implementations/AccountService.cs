using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Helpers;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Auth;
using WarThunderParody.Domain.ViewModel.UserAccount;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IRolesRepository _userRoleRepository;

    public AccountService(IAccountRepository accountRepository, IRolesRepository userRoleRepository)
    {
        _accountRepository = accountRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<BaseResponse<bool>> Register(RegisterDTO model)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var user = await _accountRepository.GetByName(model.Name);
            if (user != null)
            {
                response.StatusCode = StatusCode.AlreadyExist;
                response.Description = "Пользователь с таким логином уже есть";
            }

            var userRole = await _userRoleRepository.GetByName("User");

            List<Role> newRole = new List<Role>();
            if (userRole != null) newRole.Add(userRole);

            var newUser = new Account
            {
                Name = model.Name,
                Email = model.Email,
                Balance = 0,
                RegistrationDate = DateTime.Now,
                Password = HashPasswordHelper.HashPassword(model.Password),
                Roles = newRole
            };

            var result = await _accountRepository.Create(newUser);

            response.Data = result;
            response.StatusCode = StatusCode.OK;
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<BaseResponse<Account>> Login(LoginDTO model)
    {
        var response = new BaseResponse<Account>();
        try
        {
            var accountCheck = await _accountRepository.CheckLoginAccount(HashPasswordHelper.HashPassword(model.Password),
                model.Email);
        
            if (accountCheck != null)
            {
                response.Data = accountCheck;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            response.StatusCode = StatusCode.NotFound;
            response.Description = "Неверно указаны данные для входа, проверьте логин или пароль";
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<Account>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
       
    }

    public async Task<IBaseResponse<Account>> Edit(int id, UserAccountDTO model)
    {
        var response = new BaseResponse<Account>();
        try
        {
            var account = await _accountRepository.GetById(id);
            if (account is null)
            {
                response.Description = "Аккаунт не найден";
                response.StatusCode = StatusCode.CategoryNotFound;
                return response;
            }

            account.Name = model.Name;
            account.Balance = model.Ballance;
            account.Email = account.Email;
            account.RegistrationDate = model.RegistrationDate;
            account.Password = HashPasswordHelper.HashPassword(model.Password);
            account.Roles = model.Roles;

            await _accountRepository.Update(account);
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<Account>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}