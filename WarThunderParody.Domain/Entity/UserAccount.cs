namespace WarThunderParody.Domain.Entity;

public class UserAccount
{
    public int id { get; set; }
    public string name { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public decimal ballance { get; set; }
    public DateTime registration_date { get; set; }
    public Roles role { get; set; }
}