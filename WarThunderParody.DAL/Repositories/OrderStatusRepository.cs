using Microsoft.EntityFrameworkCore;

namespace WarThunderParody.DAL.Interfaces;

public class OrderStatusRepository : IOrderStatusRepository
{
    private readonly WarThunderShopContext _db;

    public OrderStatusRepository(WarThunderShopContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(OrderStatus entity)
    {
        await _db.OrderStatuses.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<OrderStatus?> GetById(int id)
    {
        return await _db.OrderStatuses.FirstOrDefaultAsync(x => x.Id == id);

    }

    public IQueryable<OrderStatus> GetAll()
    {
        return _db.OrderStatuses;
    }

    public async Task<OrderStatus> Update(OrderStatus entity)
    {
        _db.OrderStatuses.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(OrderStatus entity)
    {
        _db.OrderStatuses.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public Task<List<int>> GetAllId()
    {
        throw new NotImplementedException();
    }

    public async Task<OrderStatus> GetByName(string name)
    {
        return await _db.OrderStatuses.FirstOrDefaultAsync(x => x.Name == name);
    }
}