using System.ComponentModel.DataAnnotations;

namespace WarThunderParody.Domain.ViewModel.Registration;

public class RegistrationViewModel
{
    [Required(ErrorMessage = "Input email")]
    [MinLength(5, ErrorMessage = "Input email")]
    public string email { get; set; }
    [Required(ErrorMessage = "Input name")]
    [MinLength(4, ErrorMessage = "Too short name")]
    [MaxLength(50, ErrorMessage = "Too big name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Input password")]
    [MinLength(8, ErrorMessage = "Too short name")]
    [MaxLength(50, ErrorMessage = "Too big password")]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Confirm your password")]
    [Compare("Password", ErrorMessage = "Password are not same")]
    public string PasswordConfirm { get; set; }
}