using WarThunderParody.DAL.Interfaces;

namespace WarThunderParody.DAL.Repositories;

public class NationRepository : IBaseRepository<Nation>
{
    private readonly WarThunderShopContext _db;

    public NationRepository(WarThunderShopContext db)
    {
        _db = db;
    }
    public async Task<bool> Create(Nation entity)
    {
        await _db.Nations.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Nation> GetAll()
    {
        return _db.Nations;
    }

    public async Task<Nation> Update(Nation entity)
    {
        _db.Nations.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Nation entity)
    {
        _db.Nations.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}