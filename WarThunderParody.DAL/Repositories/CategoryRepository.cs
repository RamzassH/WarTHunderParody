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
        await _db.category.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Category> GetAll()
    {
        return _db.category;
    }

    public List<Category> Select()
    {
        return _db.category.ToList();
    }


    public async Task<Category> Update(Category entity)
    {
        _db.category.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Category entity)
    {
        _db.category.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public Task<Category?> GetByName(string name)
    {
        return _db.category.FirstOrDefaultAsync(x => x.name == name);
    }
}