using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Enum;

namespace WarThunderParody.DAL.Repositories;

public class CategoryRepository : IBaseRepository<Category>
{
    private readonly ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Category entity)
    {
        await _db.Category.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Category> GetAll()
    {
        return _db.Category;
    }

    public List<Category> Select()
    {
        return _db.Category.ToList();
    }


    public async Task<Category> Update(Category entity)
    {
        _db.Category.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Category entity)
    {
        _db.Category.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public Task<Category?> GetByName(string name)
    {
        return _db.Category.FirstOrDefaultAsync(x => x.Name == name);
    }
}