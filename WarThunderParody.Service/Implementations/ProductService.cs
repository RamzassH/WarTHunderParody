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

    public async Task<IBaseResponse<ProductDTO>> GetProduct(int id)
    {
        var response = new BaseResponse<ProductDTO>();
        try
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                response.Description = "Не удалось найти продукт";
                response.StatusCode = StatusCode.NotFound;
                return response;
            }

            var result = new ProductDTO
            {
                CategoryId = product.CategoryId,
                Description = product.Description,
                Id = product.Id,
                Image = product.Image,
                Name = product.Name,
                NationId = product.NationId,
                Price = product.Price
            };

            response.Data = result;
            response.StatusCode = StatusCode.NotFound;
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<ProductDTO>()
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
                    Price = product.Price,
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
                    Price = product.Price,
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
        List<int> categories,
        List<int> nations)
    {
        var response = new BaseResponse<IEnumerable<ProductDTO>>();
        try
        {
            if (nations == null)
            {
                nations = await _nationRepository.GetAllId();
            }

            if (categories == null)
            {
                categories = await _categoryRepository.GetAllId();
            }

            var products = await _productRepository.GetTechniqueByPage(limit, page, categories, nations);

            if (!products.Any())
            {
                response.Description = "Продукты не найдены";
                response.StatusCode = StatusCode.ProductNotFound;
                response.Data = new List<ProductDTO>();
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
                    Price = product.Price,
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

    public async Task<IBaseResponse<IEnumerable<Product>>> GetAllProducts()
    {
       var response = new BaseResponse<IEnumerable<Product>>();
        try
        {
            var products = await _productRepository.GetAllProducts();
            if (products == null)
            {
                response.Description = "Продукты не найдены";
                response.StatusCode = StatusCode.ProductNotFound;
                return response;
            }

            response.Data = products;
            response.StatusCode = StatusCode.OK;

            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<IBaseResponse<bool>> CreateProduct(CreateProductDTO model)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var newProduct = new Product
            {
                Name = model.Name,
                Image = model.Image,
                Price = model.Price,
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

    public async Task<IBaseResponse<ProductDTO>> GetProductById(int productId)
    {
        var response = new BaseResponse<ProductDTO>();
        try
        {
            var product = await _productRepository.GetById(productId);
            if (product == null)
            {
                response.Description = "Продукт не найден";
                response.StatusCode = StatusCode.ProductNotFound;
                return response;
            }

            var productDTO = new ProductDTO
            {
                CategoryId = product.CategoryId,
                Description = product.Description,
                Id = product.Id,
                Image = product.Image,
                Name = product.Name,
                NationId = product.NationId,
                Price = product.Price
            };

            response.Data = productDTO;
            response.StatusCode = StatusCode.OK;

            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}