using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Helpers;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Auth;
using WarThunderParody.Domain.ViewModel.UserAccount;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

 public class AccountService : IAccountService
 {
     private readonly IBaseRepository<Account> _userAccountRepository;
     private readonly ILogger<AccountService> _logger;

     public AccountService(IBaseRepository<Account> userRepository)
     {
         _userAccountRepository = userRepository;
     }

    public async Task<BaseResponse<bool>> Register(RegisterDBO model)
    {
         try
         {
             var user = await _userAccountRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
             if (user != null)
             {
                 return new BaseResponse<bool>()
                 {
                     StatusCode = StatusCode.UserAccountNotFound,
                     Description = "Пользователь с таким логином уже есть",
                 };
             }
             
             var newUser = new Account
             {
                 Name = model.Name,
                 Email = model.Email,
                 Balance = 0,
                 RegistrationDate = DateTime.UtcNow,
                 Password = HashPasswordHelper.HashPassword(model.Password)
             };

             var result = await _userAccountRepository.Create(newUser);
             var response = new BaseResponse<bool>();
             response.Data = result;
             response.StatusCode = StatusCode.OK;
             // var userRole = new UserRole
             // {
             //     RoleId = _rolesRepository.GetAll().FirstOrDefaultAsync(x => x.Name == "User");
             // }
             //await _userRoleRepository.Create();
             return response;
         }
         catch (Exception ex)
         {
             _logger.LogError(ex, $"[Register]: {ex.Message}");
             return new BaseResponse<bool>()
             {
                 Description = ex.Message,
                 StatusCode = StatusCode.InternalServerError
             };
         }
     }

    public async Task<BaseResponse<Account>> Login(LoginDBO model)
    {
        var result = await _userAccountRepository.GetAll().FirstOrDefaultAsync(x => 
            x.Password == HashPasswordHelper.HashPassword(model.Password) && x.Email == model.Email);
        var response = new BaseResponse<Account>();
        if (result != null)
        {
            response.Data = result;
            response.StatusCode = StatusCode.OK;
            return response;
        }
        
        response.StatusCode = StatusCode.NotFound;
        response.Description = "Неверно указаны данные для входа, проверьте логин или пароль";
        return response;
    }

    public async Task<IBaseResponse<Account>> Edit(int id, UserAccountDBO model)
    {
        var response = new BaseResponse<Account>();
        try
        {
            var account = await _userAccountRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
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
            
            await _userAccountRepository.Update(account);
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<Account>()
            {
                Description = $"[Edit] : {e.Message}"
            };
        }
    }
 }