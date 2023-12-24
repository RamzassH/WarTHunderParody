namespace WarThunderParody.Domain.ViewModel.History;

public class UserHitoryDTO
{
    public decimal Price { get; set; }

    public string? Image { get; set; }

    public int? NationId { get; set; }

    public string Name { get; set; } = null!;
    
    public DateOnly Date { get; set; }
}