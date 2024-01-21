using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class DCommercialAction
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public int RowIdaction { get; set; }

    public DateTime ActionDate { get; set; }

    public virtual DUser User { get; set; } = null!;
}
