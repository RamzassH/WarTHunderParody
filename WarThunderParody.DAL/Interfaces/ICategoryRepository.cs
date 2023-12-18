namespace WarThunderParody.DAL.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    public Task<Category?> GetByName(string name);

    public Task<List<Category>> GetAllCategories();
}