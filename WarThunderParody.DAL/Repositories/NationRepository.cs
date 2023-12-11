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
        await _db.nation.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Nation> GetAll()
    {
        return _db.nation;
    }

    public async Task<Nation> Update(Nation entity)
    {
        _db.nation.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Nation entity)
    {
        _db.nation.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}