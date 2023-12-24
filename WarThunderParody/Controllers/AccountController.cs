using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WarThunderParody.Domain.ViewModel.UserAccount;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [EnableCors("AllowAllMethods")]
    [HttpGet("GetAccountInfo")]
    [Authorize]
    public async Task<UserAccountDTO> GetAccountInfo()
    {
        var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwtToken);
        var email = token.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value;
        
        var response = await _accountService.GetAccountInfoByEmail(email);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return response.Data;
        }
        else
        {
            throw new Exception(response.Description);
        }
    }
    
}