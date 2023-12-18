using System;
using System.Collections.Generic;

namespace WarThunderParody;

public partial class Product
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public int? NationId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual Nation? Nation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}