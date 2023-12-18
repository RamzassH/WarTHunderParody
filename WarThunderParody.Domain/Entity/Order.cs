using System;
using System.Collections.Generic;

namespace WarThunderParody;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public DateTime Date { get; set; }

    public decimal Price { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Account User { get; set; } = null!;
}