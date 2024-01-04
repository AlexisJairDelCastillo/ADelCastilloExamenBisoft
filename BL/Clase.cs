using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Clase
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AdelCastilloExamenBisoContext context = new DL.AdelCastilloExamenBisoContext())
                {
                    var query = context.Clases.FromSqlRaw("ClaseGetAll").ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DL.Clase resultClase in query)
                        {
                            ML.Clase clase = new ML.Clase();
                            clase.IdClase = resultClase.IdClase;
                            clase.NombreClase = resultClase.NombreClase;
                            clase.Nivel = resultClase.Nivel;
                            clase.Horario = resultClase.Horario;
                            clase.Aula = resultClase.Aula;

                            result.Objects.Add(clase);
                        }
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar los registros." + ex.Message;
            }

            return result;
        }
    }
}
