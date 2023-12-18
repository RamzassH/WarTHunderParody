using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Order;
using WarThunderParody.Domain.ViewModel.Product;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<IBaseResponse<IEnumerable<Order>>> GetOrders()
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<bool>> DeleteOrder(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IBaseResponse<bool>> Create(ProductDTO model, int userId)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var order = new Order
            {
                Date = DateTime.Now.Date,
                Price = model.Price,
                ProductId = model.Id,
                UserId = userId
            };
            
            var result = await _orderRepository.Create(order);
            if (result == false)
            {
                baseResponse.Description = "Невозможно создать заказ";
                baseResponse.StatusCode = StatusCode.InternalServerError;
                return baseResponse;
            }
            
            return baseResponse;
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

    public async Task<IBaseResponse<Order>> GetOrder(int id)
    {
        var baseResponse = new BaseResponse<Order>();
        try
        {
            var category = await _orderRepository.GetById(id);
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
            return new BaseResponse<Order>()
            {
                Description = e.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public Task<IBaseResponse<Order>> Edit(int id, OrderDTO model)
    {
        throw new NotImplementedException();
    }
}