using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class DRessource
{
    public string? RpCode { get; set; }

    public string? RpIntitule { get; set; }

    public string? RpImmatriculation { get; set; }

    public short? RpEtat { get; set; }

    public int Id { get; set; }
}
