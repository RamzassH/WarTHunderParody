using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.DAL.Repositories;

public class ProductRepository : IBaseRepository<Product>
{
    public ProductRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    private readonly ApplicationDbContext _db;
    public async Task<bool> Create(Product entity)
    {
        await _db.product.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Product> GetAll()
    {
        return _db.product;
    }

    public async Task<Product> Update(Product entity)
    {
        _db.product.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Product entity)
    {
        _db.product.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}