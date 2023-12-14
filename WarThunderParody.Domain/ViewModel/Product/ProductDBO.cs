﻿namespace WarThunderParody.Domain.ViewModel.Product;

public class ProductDBO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public int? NationId { get; set; }
    //public IFormFile Avatar { get; set; }
    public string? Image { get; set; }
}