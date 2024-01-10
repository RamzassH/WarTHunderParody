using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;

namespace WarThunderParody.DAL.Repositories;

public class NationRepository : INationRepository
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

    public async Task<Nation?> GetById(int id)
    {
        return await _db.Nations.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Nation?> GetByName(string name)
    {
        return await _db.Nations.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<List<Nation>> GetAllNations()
    {
        return await _db.Nations.ToListAsync();
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

    public async Task<List<int>> GetAllId()
    {
        var listNations = await _db.Nations.ToListAsync();
        List<int> result = new List<int>();
        foreach (var nation in listNations)
        {
            result.Add(nation.Id);
        }

        return result;
    }
}