using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarThunderParody.DAL.Repositories;

public class HistoryRepository : WarThunderParody.DAL.Interfaces.IHistoryRepository
{
    private readonly WarThunderShopContext _db;

    public HistoryRepository(WarThunderShopContext db)
    {
        _db = db;
    }


    public async Task<bool> Create(History entity)
    {
        await _db.Histories.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<History?> GetById(int id)
    {
        return await _db.Histories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public IQueryable<History> GetAll()
    {
        return _db.Histories;
    }

    public async Task<History> Update(History entity)
    {
        _db.Histories.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(History entity)
    {
        _db.Histories.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}