using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;

namespace WarThunderParody.DAL.Repositories;

public class AccountRepository : IAccountRepository
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

    public async Task<Account?> GetById(int id)
    {
        return await _db.Accounts.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Account?> GetByName(string name)
    {
        return await _db.Accounts.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<Account?> GetByEmail(string email)
    {
        return await _db.Accounts.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Account?> CheckLoginAccount(string password, string email)
    {
        return await _db.Accounts.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
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

    public Task<List<int>> GetAllId()
    {
        throw new NotImplementedException();
    }
}