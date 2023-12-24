using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.ViewModel.History;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;

public class PaymentController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IHistoryService _historyService;

    public PaymentController(IOrderService orderService, IHistoryService historyService)
    {
        _orderService = orderService;
        _historyService = historyService;
    }

    public async Task<IActionResult> Payment(int orderId, string cardNumber, string cvc, string date)
    {
        var order = await _orderService.GetOrder(orderId);

        if (order.Data == null)
        {
            return BadRequest(order.Description);
        }

        
        if (order.StatusCode == Domain.Enum.StatusCode.OK && 
            cardNumber == "1234567890" && cvc == "123" && date == "12/23")
        {
            var model = new HistoryDTO
            {
                AccountId = order.Data.UserId,
                OrderId = order.Data.ProductId
            };
            await _historyService.Create(model);
            
            return Ok("Succes");
        }

        return BadRequest();
    }

}