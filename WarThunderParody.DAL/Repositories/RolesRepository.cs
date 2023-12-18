using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;

namespace WarThunderParody.DAL.Repositories;

public class RolesRepository : IRolesRepository
{
    private readonly WarThunderShopContext _db;
    public RolesRepository(WarThunderShopContext db)
    {
        _db = db;
    }
    public async Task<bool> Create(Role entity)
    {
        await _db.Roles.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Role?> GetById(int id)
    {
        return await _db.Roles.FirstOrDefaultAsync(x => x.Id == id);
    }

    public IQueryable<Role> GetAll()
    {
        return _db.Roles;
    }

    public async Task<Role> Update(Role entity)
    { 
        _db.Roles.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Role entity)
    { 
        _db.Roles.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Role?> GetByName(string name)
    {
        return await _db.Roles.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<List<Role>> GetAllRoles()
    {
        return await _db.Roles.ToListAsync();
    }

    public async  Task<List<Role>>GetRolesByUserId(int id)
    {
        var user = await _db.Accounts.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            return new List<Role>();
        }
        return user.Roles.ToList();
    }
}