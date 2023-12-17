namespace WarThunderParody.Domain.ViewModel.UserAccount;

public class UserAccountDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public decimal Ballance { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}