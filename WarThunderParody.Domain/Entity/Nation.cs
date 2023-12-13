using System.ComponentModel.DataAnnotations.Schema;

namespace WarThunderParody.Domain.Entity;

public class Nation
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
}