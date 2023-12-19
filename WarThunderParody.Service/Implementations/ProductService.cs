using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Product;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly INationRepository _nationRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductService(IProductRepository productRepository,
        INationRepository nationRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _nationRepository = nationRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
    {
        var response = new BaseResponse<IEnumerable<Product>>();
        try
        {
            var products = await _productRepository.GetAllProducts();
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
            return new BaseResponse<IEnumerable<Product>>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteProducts(int id)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var productToDelete = await _productRepository.GetById(id);
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
            return new BaseResponse<bool>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> Create(ProductDTO model)
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
            return new BaseResponse<bool>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Product>> GetProduct(int id)
    {
        var response = new BaseResponse<Product>();
        try
        {
            var result = await _productRepository.GetById(id);
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
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public Task<IBaseResponse<Product>> Edit(int id, ProductDTO model)
    {
        throw new NotImplementedException();
    }

    public async Task<IBaseResponse<IEnumerable<ProductDTO>>> GetPremiumCurrencyByPage(int limit, int page)
    {
        var response = new BaseResponse<IEnumerable<ProductDTO>>();
        try
        {
            var products = await _productRepository.GetPremiumCurrencyBaPage(limit, page);

            if (!products.Any())
            {
                response.Description = "Продукты не найдены";
                response.StatusCode = StatusCode.ProductNotFound;
                return response;
            }

            List<ProductDTO> productModelList = new List<ProductDTO>();
            foreach (var product in products)
            {
                productModelList.Add(new ProductDTO
                {
                    Name = product.Name,
                    CategoryId = (int)product.CategoryId,
                    NationId = product.NationId,
                    Description = product.Description,
                    Id = product.Id,
                    Image = product.Image
                });
            }

            response.Data = productModelList;
            response.StatusCode = StatusCode.OK;
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<ProductDTO>>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<List<ProductDTO>>> GetPremiumAccountsByPage(int limit, int page)
    {
        var response = new BaseResponse<List<ProductDTO>>();
        try
        {
            var products = await _productRepository.GetPremiumAccountByPage(limit, page);

            if (!products.Any())
            {
                response.Description = "Продукты не найдены";
                response.StatusCode = StatusCode.ProductNotFound;
                return response;
            }

            List<ProductDTO> productModelList = new List<ProductDTO>();
            foreach (var product in products)
            {
                productModelList.Add(new ProductDTO
                {
                    Name = product.Name,
                    CategoryId = (int)product.CategoryId,
                    NationId = product.NationId,
                    Description = product.Description,
                    Id = product.Id,
                    Image = product.Image
                });
            }

            response.Data = productModelList;
            response.StatusCode = StatusCode.OK;
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<List<ProductDTO>>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<ProductDTO>>> GetTechnique(int limit, int page,
        List<Category> categories,
        List<Nation> nations)
    {
        var response = new BaseResponse<IEnumerable<ProductDTO>>();
        try
        {
            if (!nations.Any())
            {
                nations = await _nationRepository.GetAllNations();
            }

            if (!categories.Any())
            {
                categories = await _categoryRepository.GetAllCategories();
            }

            List<int> nationsId = new List<int>();
            foreach (var nation in nations)
            {
                nationsId.Add((await _nationRepository.GetByName(nation.Name)).Id);
            }

            List<int> categoriesId = new List<int>();
            foreach (var category in categories)
            {
                 categoriesId.Add((await _categoryRepository.GetByName(category.Name)).Id);
            }

            if (!nationsId.Any() || !categoriesId.Any())
            {
                response.Description = "Категории или нации не найдены";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }

            var products = await _productRepository.GetTechniqueByPage(limit, page, categoriesId, nationsId);

            if (!products.Any())
            {
                response.Description = "Продукты не найдены";
                response.StatusCode = StatusCode.ProductNotFound;
                return response;
            }

            List<ProductDTO> productModelList = new List<ProductDTO>();
            foreach (var product in products)
            {
                productModelList.Add(new ProductDTO
                {
                    Name = product.Name,
                    CategoryId = (int)product.CategoryId,
                    NationId = product.NationId,
                    Description = product.Description,
                    Id = product.Id,
                    Image = product.Image
                });
            }

            response.Data = productModelList;
            response.StatusCode = StatusCode.OK;
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<ProductDTO>>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> CreateProduct(ProductDTO model)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var newProduct = new Product
            {
                Name = model.Name,
                Image = model.Image,
                Description = model.Description,
                CategoryId = model.CategoryId,
                NationId = model.NationId
            };
            response.Data = await _productRepository.Create(newProduct);
            if (response.Data)
            {
                response.StatusCode = StatusCode.OK;
            }
            else
            {
                response.StatusCode = StatusCode.NotFound;
            }

            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}