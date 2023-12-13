//using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations.Schema;

namespace WarThunderParody.Domain.Entity;

public class Product
{
    [Column("id")]
    public int Id { get; set; }
    [Column("category_id")]
    public int CategoryId { get; set; }
    [Column("nation_id")]
    public int? NationId { get; set; }
    //public IFormFile Avatar { get; set; }
    [Column("image")]
    public byte[]? Image { get; set; }
}