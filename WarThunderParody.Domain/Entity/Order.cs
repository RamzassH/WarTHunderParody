namespace WarThunderParody.Domain.Entity;

public class Order
{
    public int id { get; set; }
    public int user_id { get; set; }
    public int product_id { get; set; }
    public DateTime date { get; set; }
    public decimal price { get; set; }
}