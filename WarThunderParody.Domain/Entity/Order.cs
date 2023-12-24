using System;
using System.Collections.Generic;

namespace WarThunderParody;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public DateOnly Date { get; set; }

    public decimal Price { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual Product Product { get; set; } = null!;

    public virtual OrderStatus? Status { get; set; }

    public virtual Account User { get; set; } = null!;
}