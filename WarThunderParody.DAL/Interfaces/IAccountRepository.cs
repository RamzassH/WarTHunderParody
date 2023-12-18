namespace WarThunderParody.DAL.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    public Task<Account?> GetByName(string name);
}