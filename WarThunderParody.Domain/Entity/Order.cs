using System.ComponentModel.DataAnnotations.Schema;

namespace WarThunderParody.Domain.Entity;

public class Order
{
    [Column("id")]
    public int Id { get; set; }
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("product_id")]
    public int ProductId { get; set; }
    [Column("date")]
    public DateTime Date { get; set; }
    [Column("price")]
    public decimal Price { get; set; }
}