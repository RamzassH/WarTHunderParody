using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Order;
using WarThunderParody.Domain.ViewModel.Product;

namespace WarThunderParody.Service.Interfaces;

public interface IOrderService
{
    Task<IBaseResponse<IEnumerable<Order>>> GetOrders();
    
    Task<IBaseResponse<bool>> DeleteOrder(int id);

    Task<IBaseResponse<bool>> Create(ProductDTO model, int userId);

    Task<IBaseResponse<Order>> GetOrderByParams(int userId, int productId, string status);
    
    Task<IBaseResponse<Order>> GetOrder(int id);

    Task<IBaseResponse<Order>> Edit(int id, OrderDTO model);

    Task<IBaseResponse<bool>> AccessOrder(int id);
}