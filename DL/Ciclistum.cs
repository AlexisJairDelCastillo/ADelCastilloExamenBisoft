using System;
using System.Collections.Generic;

namespace DL;

public partial class Ciclistum
{
    public int IdCiclista { get; set; }

    public string? NombreCiclista { get; set; }

    public string? Direccion { get; set; }

    public int? Edaad { get; set; }

    public string? Nivel { get; set; }

    public bool? MembresiaActiva { get; set; }

    public virtual ICollection<CiclistaClase> CiclistaClases { get; set; } = new List<CiclistaClase>();
}
