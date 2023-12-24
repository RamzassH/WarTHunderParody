using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Category;
using WarThunderParody.Domain.ViewModel.History;
using WarThunderParody.Domain.ViewModel.Product;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class HistoryService : IHistoryService
{
    private readonly IHistoryRepository _historyRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public HistoryService(IHistoryRepository historyRepository, IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _historyRepository = historyRepository;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public Task<IBaseResponse<bool>> DeleteHistory(int id)
    {
        throw new NotImplementedException();
    }
    

    public async Task<IBaseResponse<bool>> Create(HistoryDTO model)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var newHistory = new History
            {
                AccountId = model.AccountId,
                OrderId = model.OrderId
            };
            var result = await _historyRepository.Create(newHistory);
            if (result == false)
            {
                response.Description = "Не удалось добавить в историю";
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

    public async Task<IBaseResponse<IEnumerable<UserHitoryDTO>>> GetProductsInHistoryById(int accountId)
    {
        var response = new BaseResponse<IEnumerable<UserHitoryDTO>>();
        try
        {
            var orders = await _orderRepository.GetOrdersByAccountId(accountId);
            if (!orders.Any())
            {
                response.Description = "Заказы не найдены";
                response.StatusCode = StatusCode.OrderNotFound;
                return response;
            }
            var products = await _orderRepository.GetProductByUserId(accountId);
            if (!products.Any())
            {
                response.Description = "продукты не найдены";
                response.StatusCode = StatusCode.ProductNotFound;
                return response;
            }

            var productsList = new List<UserHitoryDTO>();
            foreach (var product in products)
            {
                foreach (var order in orders)
                {
                    if (order.ProductId == product.Id)
                    {
                        productsList.Add(new UserHitoryDTO
                        {
                            Price = order.Price,
                            Date = order.Date,
                            Image = product.Image,
                            Name = product.Name,
                            NationId = product.NationId
                        });
                    }
                }
            }

            response.Data = productsList;
            response.StatusCode = StatusCode.OK;
            return response;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<IBaseResponse<History>> GetHistory(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<History>> Edit(int id, HistoryDTO model)
    {
        throw new NotImplementedException();
    }
}