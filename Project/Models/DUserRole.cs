using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class DUserRole
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string CodeRole { get; set; } = null!;
}
