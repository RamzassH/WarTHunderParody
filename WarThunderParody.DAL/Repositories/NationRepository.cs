using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.DAL.Repositories;

public class NationRepository : IBaseRepository<Nation>
{
    private readonly ApplicationDbContext _db;

    public NationRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<bool> Create(Nation entity)
    {
        await _db.Nation.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Nation> GetAll()
    {
        return _db.Nation;
    }

    public async Task<Nation> Update(Nation entity)
    {
        _db.Nation.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Nation entity)
    {
        _db.Nation.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}