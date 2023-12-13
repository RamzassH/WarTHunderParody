using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.DAL.Repositories;

public class OrderRepository : IBaseRepository<Order>
{
    private readonly ApplicationDbContext _db;
    public OrderRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<bool> Create(Order entity)
    {
        await _db.Order.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Order> GetAll()
    {
        return _db.Order;
    }

    public async Task<Order> Update(Order entity)
    {
        _db.Order.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Order entity)
    {
        _db.Order.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}