using System;
using System.Collections.Generic;

namespace WarThunderParody;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Account> Users { get; set; } = new List<Account>();
}