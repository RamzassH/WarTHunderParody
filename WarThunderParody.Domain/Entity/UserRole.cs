using System.ComponentModel.DataAnnotations.Schema;

namespace WarThunderParody.Domain.Entity;

public class UserRole
{
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("role_id")]
    public int RoleId { get; set; }
}