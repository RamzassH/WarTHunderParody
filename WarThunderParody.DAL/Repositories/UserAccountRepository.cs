using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;

namespace WarThunderParody.DAL.Repositories;

public class UserAccountRepository : IBaseRepository<Account>
{
    private readonly ApplicationDbContext _db;

    public UserAccountRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Account entity)
    {
        await _db.UserAccount.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Account> GetAll()
    {
        return _db.UserAccount;
    }

    public async Task<Account> Update(Account entity)
    {
        _db.UserAccount.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Account entity)
    {
        _db.UserAccount.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}