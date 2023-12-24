using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Category;
using WarThunderParody.Domain.ViewModel.History;
using WarThunderParody.Domain.ViewModel.Product;

namespace WarThunderParody.Service.Interfaces;

public interface IHistoryService
{
    Task<IBaseResponse<bool>> DeleteHistory(int id);
    Task<IBaseResponse<IEnumerable<UserHitoryDTO>>> GetProductsInHistoryById(int accountId);
    
    Task<IBaseResponse<bool>> Create(HistoryDTO model);

    Task<IBaseResponse<History>> GetHistory(int id);

    Task<IBaseResponse<History>> Edit(int id, HistoryDTO model);
}