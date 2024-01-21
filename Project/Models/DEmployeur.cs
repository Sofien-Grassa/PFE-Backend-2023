using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class DEmployeur
{
    public string? EmCode { get; set; }

    public string? EmPrenom { get; set; }

    public string? EmNom { get; set; }

    public string? EmFonction { get; set; }

    public short? EmEtat { get; set; }

    public int Id { get; set; }
}
