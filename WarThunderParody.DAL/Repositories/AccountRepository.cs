using WarThunderParody.DAL.Interfaces;
namespace WarThunderParody.DAL.Repositories;

public class AccountRepository : IBaseRepository<Account>
{
    private readonly WarThunderShopContext _db;

    public AccountRepository(WarThunderShopContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Account entity)
    {
        await _db.Accounts.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Account> GetAll()
    {
        return _db.Accounts;
    }

    public async Task<Account> Update(Account entity)
    {
        _db.Accounts.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Account entity)
    {
        _db.Accounts.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}