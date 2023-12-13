using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Product;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class ProductService : IProductService
{
    private IBaseRepository<Product> _productRepository;

    public ProductService(IBaseRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
    {
        var response = new BaseResponse<IEnumerable<Product>>();
        try
        {
            var products = await _productRepository.GetAll().ToListAsync();
            if (!products.Any())
            {
                response.Description = "Товары не найдены";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }

            response.Data = products;
            response.StatusCode = StatusCode.OK;
            return response;
        }
        catch (Exception e)
        {
            return  new BaseResponse<IEnumerable<Product>>()
            {
                Description = $"[GetProducts] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteProducts(int id)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var productToDelete = await _productRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (productToDelete == null)
            {
                response.Description = "Товар не найден";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }

            await _productRepository.Delete(productToDelete);
            response.StatusCode = StatusCode.OK;
            return response;
        }
        catch (Exception e)
        {
            return  new BaseResponse<bool>()
            {
                Description = $"[GetProducts] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<bool>> Create(ProductDBO model)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var newProduct = new Product
            {
                Description = model.Description,
                Image = model.Image,
                CategoryId = model.CategoryId,
                NationId = model.NationId
            };
            var result = await _productRepository.Create(newProduct);
            if (result == false)
            {
                response.Description = "Не удалось создать товар";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }

            response.StatusCode = StatusCode.OK;
            return response;
        }
        catch (Exception e)
        {
            return  new BaseResponse<bool>()
            {
                Description = $"[CreateProduct] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<Product>> GetProduct(int id)
    {
        var response = new BaseResponse<Product>();
        try
        {
            var result =  await _productRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                response.Description = "Не удалось найти продукт";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }

            response.Data = result;
            response.StatusCode = StatusCode.NotFound;
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<Product>()
            {
                Description = $"[CreateProduct] : {e.Message}"
            };
        }
    }

    public Task<IBaseResponse<Product>> Edit(int id, ProductDBO model)
    {
        throw new NotImplementedException();
    }
}