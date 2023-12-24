using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Category;
using WarThunderParody.Domain.ViewModel.Nation;
using WarThunderParody.Domain.ViewModel.Product;

namespace WarThunderParody.Service.Interfaces;

public interface IProductService
{
    Task<IBaseResponse<IEnumerable<Product>>> GetProducts();
    
    Task<IBaseResponse<bool>> DeleteProducts(int id);
    
    Task<IBaseResponse<bool>> Create(ProductDTO model);
    
    Task<IBaseResponse<ProductDTO>> GetProduct(int id);

    Task<IBaseResponse<Product>> Edit(int id, ProductDTO model);
    Task<IBaseResponse<IEnumerable<ProductDTO>>> GetPremiumCurrencyByPage(int limit, int page);
    Task<IBaseResponse<List<ProductDTO>>> GetPremiumAccountsByPage(int limit, int page);

    Task<IBaseResponse<IEnumerable<ProductDTO>>> GetTechnique(int limit, int page, List<int> categories,
        List<int> nations);

    Task<IBaseResponse<bool>> CreateProduct(CreateProductDTO model);
    Task<IBaseResponse<ProductDTO>> GetProductById(int productId);
}