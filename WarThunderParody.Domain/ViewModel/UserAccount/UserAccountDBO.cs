namespace WarThunderParody.Domain.ViewModel.UserAccount;

public class UserAccountDBO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public decimal Ballance { get; set; }
    public DateTime RegistrationDate { get; set; }
}