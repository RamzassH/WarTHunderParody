using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.DAL.Repositories;

public class UserAccountRepository : IBaseRepository<UserAccount>
{
    private readonly ApplicationDbContext _db;

    public UserAccountRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(UserAccount entity)
    {
        await _db.user_account.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<UserAccount> GetAll()
    {
        return _db.user_account;
    }

    public async Task<UserAccount> Update(UserAccount entity)
    {
        _db.user_account.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(UserAccount entity)
    {
        _db.user_account.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}