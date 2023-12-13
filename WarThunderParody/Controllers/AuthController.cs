using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WarThunderParody.Domain.Entity;
using WarThunderParody.Domain.ViewModel.Auth;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAccountService _userAccountService;
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration, IAccountService userAccountService)
    {
        _configuration = configuration;
        _userAccountService = userAccountService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDBO model)
    {
        var response = await _userAccountService.Register(model);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Ok();
        }

        return BadRequest(response.Description);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDBO model)
    {
        var result = await _userAccountService.Login(model);
        
        if (result.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return BadRequest("Invalid login attempt.");
        }
        
        var tokenString = GenerateJwtToken(result.Data);
    
        return Ok(new { Token = tokenString });
    }
    
    
    private string GenerateJwtToken(Account user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
