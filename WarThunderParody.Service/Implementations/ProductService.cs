using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Product;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class ProductService : IProductService
{
    public Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<bool>> DeleteProducts(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<ProductViewModel>> Create(ProductViewModel ProductViewModel)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Product>> GetProduct(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Product>> Edit(int id, ProductViewModel ProductViewModel)
    {
        throw new NotImplementedException();
    }
}