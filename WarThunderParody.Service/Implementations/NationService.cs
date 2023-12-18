using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Nation;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class NationService : INationService
{
   private readonly INationRepository _nationRepository;

    public NationService(INationRepository nationRepository)
    {
        _nationRepository = nationRepository;
    }

    public async Task<IBaseResponse<Nation>> GetNation(int id)
    {
        var baseResponse = new BaseResponse<Nation>();
        try
        {
            var nation = await _nationRepository.GetById(id);
            if (nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            baseResponse.Data = nation;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Nation>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Nation>> Edit(int id, NationDTO model)
    {
        var baseResponse = new BaseResponse<Nation>();
        try
        {
            var nation = await _nationRepository.GetById(id);
            if (nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            nation.Name = model.Name;
            await _nationRepository.Update(nation);
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Nation>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Nation>> GetNationByName(string name)
    {
        var baseResponse = new BaseResponse<Nation>();
        try
        {
            var nation = await _nationRepository.GetByName(name);
            if (nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            baseResponse.Data = nation;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Nation>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> Create(NationDTO model)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var nation = new Nation()
            {
                Name = "dada"
            };
            var result = await _nationRepository.Create(nation);
            if (result == false)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            await _nationRepository.Delete(nation);
            return baseResponse;
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
    
    public async Task<IBaseResponse<bool>> DeleteNation(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var nation = await _nationRepository.GetById(id);
            if (nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            await _nationRepository.Delete(nation);
            return baseResponse;
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
    public async Task<IBaseResponse<IEnumerable<Nation>>> GetNations()
    {
        var baseResponse = new BaseResponse<IEnumerable<Nation>>();
        try
        {
            var categories = await _nationRepository.GetAllNations();
            if (categories.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }

            baseResponse.Data = categories;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Nation>>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}