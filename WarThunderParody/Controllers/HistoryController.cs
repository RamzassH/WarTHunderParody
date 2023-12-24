using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WarThunderParody.Domain.ViewModel.History;
using WarThunderParody.Domain.ViewModel.Product;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;


[ApiController]
[Route("api/[controller]")]
public class HistoryController : ControllerBase
{
    private readonly IHistoryService _historyService;
    private readonly IAccountService _accountService;
    
    public HistoryController(IHistoryService historyService, IAccountService accountService)
    {
        _historyService = historyService;
        _accountService = accountService;
    }

    [EnableCors("AllowAllMethods")]
    [HttpGet("GetUserHistory")]
    [Authorize]
    public async Task<IEnumerable<UserHitoryDTO>> GetUserHistory()
    {
        var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwtToken);
        var email = token.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value;

        
        var user = await _accountService.GetAccountInfoByEmail(email);
        var response = await _historyService.GetProductsInHistoryById(user.Data.Id);

        return response.Data;
    }
}