namespace WarThunderParody.DAL.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    public Task<Product?> GetByName(string name);

    public Task<List<Product>> GetAllProducts();

    public Task<List<Product>> GetPremiumCurrencyBaPage(int limit, int page);

    public Task<List<Product>> GetPremiumAccountByPage(int limit, int page);

    public Task<List<Product>> GetTechniqueByPage(int limit, int page, List<int> categoriesId, List<int> nationsId);
}