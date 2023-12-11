namespace WarThunderParody.Domain.ViewModel.Product;

public class ProductViewModel
{
    public int id { get; set; }
    public int category_id { get; set; }
    public int? nation_id { get; set; }
    //public IFormFile Avatar { get; set; }
    public byte[]? Image { get; set; }
}