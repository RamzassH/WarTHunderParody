using System;
using System.Collections.Generic;

namespace WarThunderParody;

public partial class Account
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal Balance { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}