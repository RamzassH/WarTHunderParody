namespace WarThunderParody.Domain.ViewModel.Order;

public class OrderDBO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
}