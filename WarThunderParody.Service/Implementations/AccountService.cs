using Microsoft.EntityFrameworkCore;
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
     private readonly IBaseRepository<Account> _userAccountRepository;
     private readonly IBaseRepository<Role> _userRoleRepository;

     public AccountService(IBaseRepository<Account> userRepository, IBaseRepository<Role> userRoleRepository)
     {
         _userAccountRepository = userRepository;
         _userRoleRepository = userRoleRepository;
     }

    public async Task<BaseResponse<bool>> Register(RegisterDTO model)
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

             var userRole = await _userRoleRepository.GetAll().FirstOrDefaultAsync(x => x.Name == "User");
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

             var result = await _userAccountRepository.Create(newUser);
             
             var response = new BaseResponse<bool>();
             response.Data = result;
             response.StatusCode = StatusCode.OK;
             return response;
         }
         catch (Exception ex)
         {
             return new BaseResponse<bool>()
             {
                 Description = ex.Message,
                 StatusCode = StatusCode.InternalServerError
             };
         }
     }

    public async Task<BaseResponse<Account>> Login(LoginDTO model)
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

    public async Task<IBaseResponse<Account>> Edit(int id, UserAccountDTO model)
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
            account.Roles = model.Roles;
            
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