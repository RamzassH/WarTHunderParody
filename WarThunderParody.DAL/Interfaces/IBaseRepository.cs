

namespace WarThunderParody.DAL.Interfaces;

public interface IBaseRepository<T>
{
    public Task<bool> Create(T entity);

    IQueryable<T> GetAll();
    
    Task<T> Update(T entity);
    
    Task<bool> Delete(T entity);
}