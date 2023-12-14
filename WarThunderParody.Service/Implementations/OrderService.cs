using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Order;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class OrderService : IOrderService
{
    public Task<IBaseResponse<IEnumerable<Order>>> GetOrders()
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<bool>> DeleteOrder(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<bool>> Create(OrderDBO model)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Order>> GetOrder(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Order>> Edit(int id, OrderDBO model)
    {
        throw new NotImplementedException();
    }
}