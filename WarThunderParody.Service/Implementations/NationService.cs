using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Nation;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class NationService : INationService
{
   private readonly IBaseRepository<Nation> _NationRepository;

    public NationService(IBaseRepository<Nation> NationRepository)
    {
        _NationRepository = NationRepository;
    }

    public async Task<IBaseResponse<Nation>> GetNation(int id)
    {
        var baseResponse = new BaseResponse<Nation>();
        try
        {
            var Nation = await _NationRepository.GetAll().FirstOrDefaultAsync(x => x.id == id);
            if (Nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            baseResponse.Data = Nation;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Nation>()
            {
                Description = $"[GetNation] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<Nation>> Edit(int id, NationViewModel NationViewModel)
    {
        var baseResponse = new BaseResponse<Nation>();
        try
        {
            var Nation = await _NationRepository.GetAll().FirstOrDefaultAsync(x => x.id == id);
            if (Nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            Nation.name = NationViewModel.name;
            await _NationRepository.Update(Nation);
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Nation>()
            {
                Description = $"[Edit] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<Nation>> GetNationByName(string name)
    {
        var baseResponse = new BaseResponse<Nation>();
        try
        {
            var Nation = await _NationRepository.GetAll().FirstOrDefaultAsync(x => x.name == name);
            if (Nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            baseResponse.Data = Nation;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Nation>()
            {
                Description = $"[GetNationByName] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<NationViewModel>> Create(NationViewModel NationViewModel)
    {
        var baseResponse = new BaseResponse<NationViewModel>();
        try
        {
            var Nation = new Nation()
            {
                name = "dada"
            };
            await _NationRepository.Create(Nation);
            if (Nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            await _NationRepository.Delete(Nation);
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<NationViewModel>()
            {
                Description = $"[CreateNation] : {e.Message}"
            };
        }
    }
    
    public async Task<IBaseResponse<bool>> DeleteNation(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var Nation = await _NationRepository.GetAll().FirstOrDefaultAsync(x => x.id == id);
            if (Nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            await _NationRepository.Delete(Nation);
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteNation] : {e.Message}"
            };
        }
    }
    public async Task<IBaseResponse<IEnumerable<Nation>>> GetNations()
    {
        var baseResponse = new BaseResponse<IEnumerable<Nation>>();
        try
        {
            var categories = await _NationRepository.GetAll().ToListAsync();
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
                Description = $"[GetNations] : {e.Message}"
            };
        }
    }
}