using Microsoft.EntityFrameworkCore;
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
        await _db.UserRole.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<UserRole> GetAll()
    {
        return _db.UserRole;
    }

    public async Task<UserRole> Update(UserRole entity)
    {
        _db.UserRole.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(UserRole entity)
    {
        _db.UserRole.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}