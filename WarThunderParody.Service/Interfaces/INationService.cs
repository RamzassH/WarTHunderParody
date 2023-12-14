using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Nation;

namespace WarThunderParody.Service.Interfaces;

public interface INationService
{
    Task<IBaseResponse<IEnumerable<Nation>>> GetNations();
    Task<IBaseResponse<bool>> DeleteNation(int id);
    Task<IBaseResponse<bool>> Create(NationDBO model);
    Task<IBaseResponse<Nation>> GetNationByName(string name);

    Task<IBaseResponse<Nation>> GetNation(int id);

    Task<IBaseResponse<Nation>> Edit(int id, NationDBO model);
}
