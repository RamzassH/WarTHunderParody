using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.DAL.Repositories;

public class OrderRepository : IBaseRepository<Order>
{
    public OrderRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    private readonly ApplicationDbContext _db;
    public async Task<bool> Create(Order entity)
    {
        await _db.order.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Order> GetAll()
    {
        return _db.order;
    }

    public async Task<Order> Update(Order entity)
    {
        _db.order.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Order entity)
    {
        _db.order.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}