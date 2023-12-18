using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WarThunderParody.Domain.ViewModel.Auth;
using WarThunderParody.Domain.ViewModel.Product;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;

public class OrderController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;


    public OrderController(IProductService productService, IOrderService orderService)
    {
        _productService = productService;
        _orderService = orderService;
    }

    [Authorize]
    [Microsoft.AspNetCore.Mvc.HttpPost("Purchase")]
    public async Task<IActionResult> Purchase(int productId)
    {
        var product = await _productService.GetProduct(productId);
        if (product.Data == null)
        {
            return BadRequest(product.Description);
        }

        string authorizationHeader = Request.Headers["Authorization"];
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(authorizationHeader);
        var userIdClaim = token.Claims.First(claim => claim.Type == "id");
        var userId = int.Parse(userIdClaim.Value);

        var model = new ProductDTO
        {
            Name = product.Data.Name,
            CategoryId = product.Data.CategoryId,
            Price = product.Data.Price,
            Id = product.Data.Id
        };
        
        var order = await _orderService.Create(model, userId);
        if (order.Data == null)
        {
            return BadRequest(order.Description);
        }
        
        return Ok();
    }
}