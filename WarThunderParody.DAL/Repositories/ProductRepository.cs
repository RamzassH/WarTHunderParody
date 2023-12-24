using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;

namespace WarThunderParody.DAL.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly WarThunderShopContext _db;
    private readonly ICategoryRepository _categoryRepository;
    
    public ProductRepository(WarThunderShopContext db, ICategoryRepository categoryRepository)
    {
        _db = db;
        _categoryRepository = categoryRepository;
    }
    
    public async Task<bool> Create(Product entity)
    {
        await _db.Products.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Product?> GetById(int id)
    {
        return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public IQueryable<Product> GetAll()
    {
        return _db.Products;
    }

    public async Task<Product> Update(Product entity)
    {
        _db.Products.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Product entity)
    {
        _db.Products.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public Task<List<int>> GetAllId()
    {
        throw new NotImplementedException();
    }

    public async Task<Product?> GetByName(string name)
    {
        return await _db.Products.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await _db.Products.ToListAsync();
    }

    public async Task<List<Product>> GetAllProductsById(int id)
    {
        return await _db.Products.Where(x => x.Id == id).ToListAsync();
    }

    public async Task<List<Product>> GetPremiumCurrencyBaPage(int limit, int page)
    {
        var premiumCurrency = await _categoryRepository.GetByName("Premium currency");
        if (premiumCurrency == null)
        {
            return  new List<Product>();
        }
        return await _db.Products.Where(x =>
            x.CategoryId == premiumCurrency.Id).Skip((page - 1) * limit).Take(limit).ToListAsync();
    }

    public async Task<List<Product>> GetPremiumAccountByPage(int limit, int page)
    {
        var premiumAccount = await _categoryRepository.GetByName("Premium account");
        if (premiumAccount == null)
        {
            return  new List<Product>();
        }
        return await _db.Products.Where(x =>
            x.CategoryId == premiumAccount.Id).Skip((page - 1) * limit).Take(limit).ToListAsync();
    }

    public async Task<List<Product>> GetTechniqueByPage(int limit, int page, List<int> categoriesId, List<int> nationsId)
    {
        var products = await _db.Products
            .Where(x => nationsId.Contains(x.NationId ?? -1) 
                        && categoriesId.Contains(x.CategoryId ))
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();
        return products;
    }
}