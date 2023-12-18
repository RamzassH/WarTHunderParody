using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Order;
using WarThunderParody.Domain.ViewModel.Product;

namespace WarThunderParody.Service.Interfaces;

public interface IOrderService
{
    Task<IBaseResponse<IEnumerable<Order>>> GetOrders();
    
    Task<IBaseResponse<bool>> DeleteOrder(int id);

    public Task<IBaseResponse<bool>> Create(ProductDTO model, int userId);
    
    Task<IBaseResponse<Order>> GetOrder(int id);

    Task<IBaseResponse<Order>> Edit(int id, OrderDTO model);
}