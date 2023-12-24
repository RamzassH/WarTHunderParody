using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.ViewModel.Product;

namespace WarThunderParody.DAL.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly WarThunderShopContext _db;

    public OrderRepository(WarThunderShopContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Order entity)
    {
        await _db.Orders.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Order?> GetById(int id)
    {
        return await _db.Orders.FirstOrDefaultAsync(x => x.Id == id);
    }

    public IQueryable<Order> GetAll()
    {
        return _db.Orders;
    }

    public async Task<Order> Update(Order entity)
    {
        _db.Orders.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Order entity)
    {
        _db.Orders.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<List<Order>> GetOrdersByAccountId(int accountId)
    {
        return await _db.Orders.Where(x => x.UserId == accountId).Include(o => o.Product).ToListAsync();
    }

    public async Task<Order> GetOrderByParams(int userId, int productId, string status)
    {
        var orderStatus = await _db.OrderStatuses.FirstOrDefaultAsync(y => y.Name == status);
        return await _db.Orders.FirstOrDefaultAsync(x =>
            x.UserId == userId && x.ProductId == productId &&
            x.StatusId == orderStatus.Id);
    }

    public async Task<List<Product>> GetProductByUserId(int userId)
    {
        var products = await _db.Orders
            .Where(x => x.UserId == userId)
            .Select(x => x.Product)
            .Distinct()
            .ToListAsync();
        return products;
    }

    public Task<List<int>> GetAllId()
    {
        throw new NotImplementedException();
    }
}