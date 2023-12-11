using Microsoft.AspNetCore.Mvc;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.ViewModel.Registration;
using WarThunderParody.Service.Implementations;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly IAccountService _accountService;

    public RegistrationController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    [HttpPost]
    public async Task<bool> Register(RegistrationViewModel model)
    {
        model = new RegistrationViewModel()
        {
            Name = "Andrei",
            email = "sobaka@mail.ru",
            Password = "JaSosuBibu",
            PasswordConfirm = "JaSosuBibu"
        };
        var response = await _accountService.Register(model);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return true;
        }

        return false;
    }
}