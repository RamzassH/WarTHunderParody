using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WarThunderParody.Domain.ViewModel.History;
using WarThunderParody.Service.Interfaces;


namespace WarThunderParody.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;
    private readonly IHistoryService _historyService;


    public OrderController(IProductService productService, IOrderService orderService, 
        IAccountService accountService, IHistoryService historyService)
    {
        _productService = productService;
        _orderService = orderService;
        _accountService = accountService;
        _historyService = historyService;
    }

    [EnableCors("AllowAllMethods")]
    [HttpPost("Purchase")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> Purchase(int productId, string cardNum, string cardDate, string cvc)
    {
        var product = await _productService.GetProduct(productId);
        
        var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwtToken);
        var email = token.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value;
        
        var accountResponse = await _accountService.GetAccountInfoByEmail(email);
        var productResponse = await _productService.GetProductById(productId);

        if (accountResponse.StatusCode != Domain.Enum.StatusCode.OK ||
            productResponse.StatusCode != Domain.Enum.StatusCode.OK)
        {
            return BadRequest(accountResponse.Description  + ' '+ productResponse.Description);
        }

        var order =
            await _orderService.GetOrderByParams(accountResponse.Data.Id, productResponse.Data.Id, "Не оплачен");
        
        if (order.StatusCode != Domain.Enum.StatusCode.OK)
        {
            if ((await _orderService.Create(productResponse.Data, accountResponse.Data.Id)).StatusCode !=  Domain.Enum.StatusCode.OK)
            {
                return BadRequest();
            }
        }
        order = await _orderService.GetOrderByParams(accountResponse.Data.Id, productResponse.Data.Id, "Не оплачен");

        
        if (cardNum != "123456789" && cardDate != "12/34" && cvc != "123")
        {
            return BadRequest("Оплата не удалась");
        }

        await _orderService.AccessOrder(order.Data.Id);
        var historyDTO = new HistoryDTO
        {
            AccountId = accountResponse.Data.Id,
            OrderId = order.Data.Id
        };
        await _historyService.Create(historyDTO);
        
        return Ok();
    }
    
    // [Authorize]
    // [Microsoft.AspNetCore.Mvc.HttpPost("GetHistory")]
    // public async Task<IActionResult> GetHistory(int accountId)
    // {
    //     var product = await _productService.GetProduct(productId);
    //     if (product.Data == null)
    //     {
    //         return BadRequest(product.Description);
    //     }
    //
    //     string authorizationHeader = Request.Headers["Authorization"];
    //     var handler = new JwtSecurityTokenHandler();
    //     var token = handler.ReadJwtToken(authorizationHeader);
    //     var userIdClaim = token.Claims.First(claim => claim.Type == "id");
    //     var userId = int.Parse(userIdClaim.Value);
    //
    //     var model = new ProductDTO
    //     {
    //         Name = product.Data.Name,
    //         CategoryId = product.Data.CategoryId,
    //         Price = product.Data.Price,
    //         Id = product.Data.Id
    //     };
    //     
    //     var order = await _orderService.Create(model, userId);
    //     if (order.Data == null)
    //     {
    //         return BadRequest(order.Description);
    //     }
    //     return Ok();
    // }
}