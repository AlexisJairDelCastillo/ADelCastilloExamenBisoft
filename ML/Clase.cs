using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Clase
    {
        public int IdClase { get; set; }

        public string? NombreClase { get; set; }

        public string? Nivel { get; set; }

        public string? Horario { get; set; }

        public string? Aula { get; set; }

        public List<object> Clases { get; set; }
    }
}
