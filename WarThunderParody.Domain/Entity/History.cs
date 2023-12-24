using System;
using System.Collections.Generic;

namespace WarThunderParody;

public partial class History
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int OrderId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
