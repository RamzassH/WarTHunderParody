namespace WarThunderParody.DAL.Interfaces;

public interface IOrderStatusRepository : IBaseRepository<OrderStatus>
{
    Task<OrderStatus> GetByName(string name);
}