using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Product;

namespace WarThunderParody.DAL.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<List<Order>> GetOrdersByAccountId(int accountId);

    Task<Order> GetOrderByParams(int userId, int productId, string status);
    Task<List<Product>> GetProductByUserId(int userId);
}