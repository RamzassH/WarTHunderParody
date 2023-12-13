using System.ComponentModel.DataAnnotations.Schema;
using WarThunderParody.Domain.Enum;

namespace WarThunderParody.Domain.Entity;

public class Category
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
}