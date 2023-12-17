using System.ComponentModel.DataAnnotations;

namespace WarThunderParody.Domain.ViewModel.Auth;

public class UserEmailDTO
{
    [Required(ErrorMessage = "Введите e-mail")]
    public string Email { get; set; }
}