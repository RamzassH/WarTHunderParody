using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;

namespace WarThunderParody.DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly WarThunderShopContext _db;

    public CategoryRepository(WarThunderShopContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Category entity)
    {
        await _db.Categories.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Category?> GetById(int id)
    {
        return await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public IQueryable<Category> GetAll()
    {
        return _db.Categories;
    }
    
    public async Task<Category> Update(Category entity)
    {
        _db.Categories.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Category entity)
    {
        _db.Categories.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public Task<Category?> GetByName(string name)
    {
        return _db.Categories.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<List<Category>> GetAllCategories()
    {
        return await _db.Categories.ToListAsync();
    }
}