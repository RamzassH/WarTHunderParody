namespace WarThunderParody.Domain.ViewModel.Product;

public class ProductDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int? NationId { get; set; }
    public string? Image { get; set; }
}