using System.ComponentModel.DataAnnotations.Schema;

namespace WarThunderParody.Domain.Entity;

public class Account
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("balance")]
    public decimal Balance { get; set; }
    [Column("registration_date")]
    public DateTime RegistrationDate { get; set; }
}