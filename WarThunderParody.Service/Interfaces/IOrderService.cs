using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Order;

namespace WarThunderParody.Service.Interfaces;

public interface IOrderService
{
    Task<IBaseResponse<IEnumerable<Order>>> GetOrders();
    
    Task<IBaseResponse<bool>> DeleteOrder(int id);
    
    Task<IBaseResponse<OrderDBO>> Create(OrderDBO orderDbo);
    
    Task<IBaseResponse<Order>> GetOrder(int id);

    Task<IBaseResponse<Order>> Edit(int id, OrderDBO orderDbo);
}