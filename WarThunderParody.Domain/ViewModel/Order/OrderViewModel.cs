namespace WarThunderParody.Domain.ViewModel.Order;

public class OrderViewModel
{
    public int id { get; set; }
    public int user_id { get; set; }
    public int product_id { get; set; }
    public DateTime date { get; set; }
    public decimal price { get; set; }
}