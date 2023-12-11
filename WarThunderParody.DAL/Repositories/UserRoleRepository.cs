using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.DAL.Repositories;

public class UserRoleRepository : IBaseRepository<UserRole>
{
    private readonly ApplicationDbContext _db;

    public UserRoleRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    
    public async Task<bool> Create(UserRole entity)
    {
        await _db.user_role.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<UserRole> GetAll()
    {
        return _db.user_role;
    }

    public async Task<UserRole> Update(UserRole entity)
    {
        _db.user_role.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(UserRole entity)
    {
        _db.user_role.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}