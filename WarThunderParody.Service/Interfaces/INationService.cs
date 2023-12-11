using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Category;
using WarThunderParody.Domain.ViewModel.Nation;

namespace WarThunderParody.Service.Interfaces;

public interface INationService
{
    Task<IBaseResponse<IEnumerable<Nation>>> GetNations();
    Task<IBaseResponse<bool>> DeleteNation(int id);
    Task<IBaseResponse<NationViewModel>> Create(NationViewModel categoryViewModel);
    Task<IBaseResponse<Nation>> GetNationByName(string name);

    Task<IBaseResponse<Nation>> GetNation(int id);

    Task<IBaseResponse<Nation>> Edit(int id, NationViewModel categoryViewModel);
}
