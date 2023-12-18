using WarThunderParody.Domain.ViewModel.Category;
using WarThunderParody.Domain.ViewModel.Nation;

namespace WarThunderParody.Domain.ViewModel.Product;

public class GetTechniqueDTO
{
    public int Limit { get; set; }
    public int Page { get; set; }
    public List<CategoryDTO> Categories { get; set; }
    public List<NationDTO> Nations { get; set; }
}