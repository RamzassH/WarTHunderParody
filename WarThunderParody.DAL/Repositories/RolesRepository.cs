using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.DAL.Repositories;

public class RolesRepository : IBaseRepository<Roles>
{
    public RolesRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    private readonly ApplicationDbContext _db;
    public async Task<bool> Create(Roles entity)
    {
        await _db.roles.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Roles> GetAll()
    {
        return _db.roles;
    }

    public async Task<Roles> Update(Roles entity)
    { 
        _db.roles.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Roles entity)
    { 
        _db.roles.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}