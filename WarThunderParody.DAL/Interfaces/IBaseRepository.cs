using WarThunderParody.Domain.Entity;

namespace WarThunderParody.DAL.Interfaces;

public interface IBaseRepository<T>
{
    Task<bool> Create(T entity);

    IQueryable<T> GetAll();

    List<Category> Select();
    
    Task<T> Update(T entity);
    
    Task<bool> Delete(T entity);
}