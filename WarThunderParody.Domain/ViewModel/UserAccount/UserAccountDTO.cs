namespace WarThunderParody.Domain.ViewModel.UserAccount;

public class UserAccountDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Ballance { get; set; }
    public DateOnly RegistrationDate { get; set; }
}