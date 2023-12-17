using System.ComponentModel.DataAnnotations;

namespace WarThunderParody.Domain.ViewModel.Auth;

public class LoginDTO
{
    [Required(ErrorMessage = "Введите e-mail")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Введите пароль")]
    [MinLength(8)]
    public string Password { get; set; }
}