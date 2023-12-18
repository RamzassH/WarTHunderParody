using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Roles;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class RolesService : IRolesService
{
    private readonly IRolesRepository _rolesRepository;
    private readonly IAccountRepository _accountRepository;
    
    
    public RolesService(IRolesRepository userRepository,
        IAccountRepository accountRepository)
    {
        _rolesRepository = userRepository;
        _accountRepository = accountRepository;
    }

    public async Task<IBaseResponse<IEnumerable<Role>>> GetRoles()
    {
        var response = new BaseResponse<IEnumerable<Role>>();
        try
        {
            var roles = await _rolesRepository.GetAllRoles();
            if (roles.Count == 0)
            {
                response.Description = "Найдено 0 элементов";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }

            response.Data = roles;
            response.StatusCode = StatusCode.OK;
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Role>>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteRole(int id)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var roleToDelete = await _rolesRepository.GetById(id);

            if (roleToDelete == null)
            {
                response.Description = "Найдено 0 элементов";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }

            response.StatusCode = StatusCode.OK;
            await _rolesRepository.Delete(roleToDelete);
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

    public async Task<IBaseResponse<bool>> Create(RolesDTO model)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var role = new Role
            {
                Name = model.Name
            };
            var result = await _rolesRepository.Create(role);
            if (result == false)
            {
                response.Description = "Роль не создана";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }
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

    public async Task<IBaseResponse<IEnumerable<Role>>> GetUserRolesByUserId(int id)
    {
        var response = new BaseResponse<IEnumerable<Role>>();
        try
        {
            var roles = await _rolesRepository.GetRolesByUserId(id);
            
            if (!roles.Any())
            {
                response.Description = "Пользователь не найден";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }
            

            response.Data = roles; 
            response.StatusCode = StatusCode.OK;
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Role>>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

     public async Task<IBaseResponse<Account>> MakeUserAdmin(string email)
     {
         var response = new BaseResponse<Account>();
         try
         {
             var user = await _accountRepository.GetByEmail(email);
             if (user == null)
             {
                 response.Description = "Пользователь не найден";
                 response.StatusCode = StatusCode.NotFound;
                 return response;
             }

             var adminRole = await _rolesRepository.GetByName("Admin");
             if (adminRole == null)
             {
                 response.Description = "Роль не найдена";
                 response.StatusCode = StatusCode.NotFound;
                 return response;
             }
            
             user.Roles.Add(adminRole);
             adminRole.Users.Add(user);
             
             await _rolesRepository.Update(adminRole);
             response.Data = await _accountRepository.Update(user);
             response.StatusCode = StatusCode.OK;
             return response;
         }
         catch (Exception e)
         {
             return new BaseResponse<Account>
             {
                 Description = e.Message,
                 StatusCode = StatusCode.InternalServerError
             };
         }
    }


    public Task<IBaseResponse<Role>> GetRole(int id)
    {
        throw new NotImplementedException();
    }
    public Task<IBaseResponse<Role>> GetRoleByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Role>> Edit(int id, RolesDTO model)
    {
        throw new NotImplementedException();
    }
}