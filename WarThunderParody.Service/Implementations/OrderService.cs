using Microsoft.AspNetCore.Components.Web;
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
    private readonly IOrderStatusRepository _orderStatusRepository;

    public OrderService(IOrderRepository orderRepository, IOrderStatusRepository orderStatusRepository)
    {
        _orderRepository = orderRepository;
        _orderStatusRepository = orderStatusRepository;
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
                Date = DateOnly.FromDateTime(DateTime.Now),
                Price = model.Price,
                ProductId = model.Id,
                UserId = userId,
                StatusId =  (await _orderStatusRepository.GetByName("Не оплачен")).Id
            };
            
            var result = await _orderRepository.Create(order);
            if (result == false)
            {
                baseResponse.Description = "Невозможно создать заказ";
                baseResponse.StatusCode = StatusCode.InternalServerError;
                return baseResponse;
            }

            baseResponse.StatusCode = StatusCode.OK;
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

    public async Task<IBaseResponse<Order>> GetOrderByParams(int userId, int productId, string status)
    {
        var baseResponse = new BaseResponse<Order>();
        try
        {
            var order = await _orderRepository.GetOrderByParams(userId, productId, status);
            
            if (order is null)
            {
                baseResponse.Description = "Order not found";
                baseResponse.StatusCode = StatusCode.OrderNotFound;
                return baseResponse;
            }

            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = order;
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

    public async Task<IBaseResponse<bool>> AccessOrder(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var order = await _orderRepository.GetById(id);
            if (order is null)
            {
                baseResponse.Description = "Order not found";
                baseResponse.StatusCode = StatusCode.CategoryNotFound;
                return baseResponse;
            }

            var accessStatusId = (await _orderStatusRepository.GetByName("Оплачен")).Id;
            order.StatusId = accessStatusId;
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = true;
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
}