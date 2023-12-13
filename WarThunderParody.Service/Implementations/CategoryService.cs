using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Category;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;


public class CategoryService : ICategoryService
{
    private readonly IBaseRepository<Category> _categoryRepository;

    public CategoryService(IBaseRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IBaseResponse<Category>> GetCategory(int id)
    {
        var baseResponse = new BaseResponse<Category>();
        try
        {
            var category = await _categoryRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
            {
                baseResponse.Description = "Category not found";
                baseResponse.StatusCode = StatusCode.CategoryNotFound;
                return baseResponse;
            }

            baseResponse.Data = category;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Category>()
            {
                Description = $"[GetCategory] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<Category>> Edit(int id, CategoryDBO categoryDbo)
    {
        var baseResponse = new BaseResponse<Category>();
        try
        {
            var category = await _categoryRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
            {
                baseResponse.Description = "Category not found";
                baseResponse.StatusCode = StatusCode.CategoryNotFound;
                return baseResponse;
            }

            category.Name = categoryDbo.Name;
            await _categoryRepository.Update(category);
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Category>()
            {
                Description = $"[Edit] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<Category>> GetCategoryByName(string name)
    {
        var baseResponse = new BaseResponse<Category>();
        try
        {
            var category = await _categoryRepository.GetAll().FirstOrDefaultAsync(x => x.Name == name);
            if (category is null)
            {
                baseResponse.Description = "Category not found";
                baseResponse.StatusCode = StatusCode.CategoryNotFound;
                return baseResponse;
            }

            baseResponse.Data = category;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Category>()
            {
                Description = $"[GetCategoryByName] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<CategoryDBO>> Create(CategoryDBO categoryDbo)
    {
        var baseResponse = new BaseResponse<CategoryDBO>();
        try
        {
            var category = new Category()
            {
                Name = categoryDbo.Name
            };
            if (category is null)
            {
                baseResponse.Description = "Category not found";
                baseResponse.StatusCode = StatusCode.CategoryNotFound;
                return baseResponse;
            }
            await _categoryRepository.Create(category);
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<CategoryDBO>()
            {
                Description = $"[CreateCategory] : {e.Message}"
            };
        }
    }
    
    public async Task<IBaseResponse<bool>> DeleteCategory(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var category = await _categoryRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
            {
                baseResponse.Description = "Category not found";
                baseResponse.StatusCode = StatusCode.CategoryNotFound;
                return baseResponse;
            }

            await _categoryRepository.Delete(category);
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteCategory] : {e.Message}"
            };
        }
    }
    public async Task<IBaseResponse<IEnumerable<Category>>> GetCategories()
    {
        var baseResponse = new BaseResponse<IEnumerable<Category>>();
        try
        {
            var categories = await _categoryRepository.GetAll().ToListAsync();
            if (categories.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }

            baseResponse.Data = categories;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Category>>()
            {
                Description = $"[GetCategories] : {e.Message}"
            };
        }
    }
}