using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Nation;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class NationService : INationService
{
    public Task<IBaseResponse<IEnumerable<Nation>>> GetNations()
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<bool>> DeleteNation(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<NationViewModel>> Create(NationViewModel categoryViewModel)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Nation>> GetNationByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Nation>> GetNation(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Nation>> Edit(int id, NationViewModel categoryViewModel)
    {
        throw new NotImplementedException();
    }
}