using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class DRessourcePanneArrêt
{
    public int Id { get; set; }

    public string? RpCode { get; set; }

    public short? RpEtat { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }
}
