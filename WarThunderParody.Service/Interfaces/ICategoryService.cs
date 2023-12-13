using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Category;

namespace WarThunderParody.Service.Interfaces;

public interface ICategoryService
{
    Task<IBaseResponse<IEnumerable<Category>>> GetCategories();
    Task<IBaseResponse<bool>> DeleteCategory(int id);
    Task<IBaseResponse<CategoryDBO>> Create(CategoryDBO categoryDbo);
    Task<IBaseResponse<Category>> GetCategoryByName(string name);

    Task<IBaseResponse<Category>> GetCategory(int id);

    Task<IBaseResponse<Category>> Edit(int id, CategoryDBO categoryDbo);
}
