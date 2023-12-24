

namespace WarThunderParody.DAL.Interfaces;

public interface IBaseRepository<T>
{
    public Task<bool> Create(T entity);

    public Task<T?> GetById(int id);
    
    public IQueryable<T> GetAll();
    
    public Task<T> Update(T entity);
    
    public Task<bool> Delete(T entity);

    public Task<List<int>> GetAllId();
}