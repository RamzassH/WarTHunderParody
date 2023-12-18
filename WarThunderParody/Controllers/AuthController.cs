using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WarThunderParody.Domain.ViewModel.Auth;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAccountService _userAccountService;
    private readonly IRolesService _rolesService;
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration, IAccountService userAccountService, IRolesService rolesService)
    {
        _configuration = configuration;
        _userAccountService = userAccountService;
        _rolesService = rolesService;
    }

    [Microsoft.AspNetCore.Mvc.HttpPost("register")]
    public async Task<IActionResult> Register([Microsoft.AspNetCore.Mvc.FromBody] RegisterDTO model)
    {
        var response = await _userAccountService.Register(model);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            WarThunderShopContext.BackupDatabase();
            return Ok();
        }

        return BadRequest(response.Description);
    }

    [Microsoft.AspNetCore.Mvc.HttpPost("login")]
    public async Task<IActionResult> Login([Microsoft.AspNetCore.Mvc.FromBody] LoginDTO model)
    {
        var result = await _userAccountService.Login(model);
        
        if (result.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return BadRequest("Invalid login attempt.");
        }
        
        var tokenString = await GenerateJwtToken(result.Data);
    
        return Ok(new { Token = tokenString });
    }

    
    [Authorize(Roles = "Admin")]
    [Microsoft.AspNetCore.Mvc.HttpPost("MakeUserAdmin")]
    public async Task<IActionResult> CreateUserAdmin([Microsoft.AspNetCore.Mvc.FromBody] UserEmailDTO model)
    {
        var result = await _rolesService.MakeUserAdmin(model.Email);
        if (result.StatusCode == Domain.Enum.StatusCode.NotFound)
        {
            return BadRequest(result.Description);
        }

        return Ok();
    }
    
    private async Task<string> GenerateJwtToken(Account user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);
        var roles = await _rolesService.GetUserRolesByUserId(user.Id);
        
        List<Claim> claims = new List<Claim>();
        foreach (var role in roles.Data)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
        }
        claims.Add(new Claim(ClaimTypes.Name, user.Name));
        claims.Add( new Claim(ClaimTypes.Email, user.Email));
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    

}
