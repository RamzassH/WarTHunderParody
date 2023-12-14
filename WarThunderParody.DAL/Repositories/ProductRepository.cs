using WarThunderParody.DAL.Interfaces;

namespace WarThunderParody.DAL.Repositories;

public class ProductRepository : IBaseRepository<Product>
{
    public ProductRepository(WarThunderShopContext db)
    {
        _db = db;
    }
    private readonly WarThunderShopContext _db;
    public async Task<bool> Create(Product entity)
    {
        await _db.Products.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Product> GetAll()
    {
        return _db.Products;
    }

    public async Task<Product> Update(Product entity)
    {
        _db.Products.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Product entity)
    {
        _db.Products.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}