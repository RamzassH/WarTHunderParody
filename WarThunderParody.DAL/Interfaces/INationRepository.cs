namespace WarThunderParody.DAL.Interfaces;

public interface INationRepository : IBaseRepository<Nation>
{
    public Task<Nation?> GetByName(string name);

    public Task<List<Nation>> GetAllNations();
}