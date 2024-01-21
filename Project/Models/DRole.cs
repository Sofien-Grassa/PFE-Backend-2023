using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class DRole
{
    public int Id { get; set; }

    public string CodeRole { get; set; } = null!;

    public string? NomRole { get; set; }
}
