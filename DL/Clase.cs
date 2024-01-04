using System;
using System.Collections.Generic;

namespace DL;

public partial class Clase
{
    public int IdClase { get; set; }

    public string? NombreClase { get; set; }

    public string? Nivel { get; set; }

    public string? Horario { get; set; }

    public string? Aula { get; set; }

    public virtual ICollection<CiclistaClase> CiclistaClases { get; set; } = new List<CiclistaClase>();
}
