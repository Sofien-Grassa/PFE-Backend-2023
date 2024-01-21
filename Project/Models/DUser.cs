using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class DUser
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Adresse { get; set; }

    public string? Email { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public short Etat { get; set; }

    public virtual ICollection<DCommercialAction> DCommercialActions { get; } = new List<DCommercialAction>();
}
