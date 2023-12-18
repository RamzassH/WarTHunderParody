using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Category;
using WarThunderParody.Domain.ViewModel.History;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class HistoryService : IHistoryService
{
    private readonly IHistoryService _historyService;

    public HistoryService(IHistoryService historyService)
    {
        _historyService = historyService;
    }

    public Task<IBaseResponse<bool>> DeleteHistory(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IBaseResponse<bool>> Create(HistoryDTO model)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var result = await _historyService.Create(model);
            if (result.Data == false)
            {
                response.Description = "Не удалось добавить в историю";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }

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

    public Task<IBaseResponse<History>> GetHistory(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<History>> Edit(int id, HistoryDTO model)
    {
        throw new NotImplementedException();
    }
}