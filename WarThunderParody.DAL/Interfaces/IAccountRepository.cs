namespace WarThunderParody.DAL.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    public Task<Account?> GetByName(string name);

    public Task<Account?> GetByEmail(string email);

    public Task<Account?> CheckLoginAccount(string password, string email);
}