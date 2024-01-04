using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CiclistaClase
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AdelCastilloExamenBisoContext context = new DL.AdelCastilloExamenBisoContext())
                {
                    var query = context.CiclistaClases.FromSqlRaw("CiclistaClaseGetAll").ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DL.CiclistaClase resultCiclistaClase in query)
                        {
                            ML.CiclistaClase ciclistaClase = new ML.CiclistaClase();
                            ciclistaClase.IdRelacion = resultCiclistaClase.IdRelacion;
                            ciclistaClase.Ciclista = new ML.Ciclista();
                            ciclistaClase.Ciclista.IdCiclista = resultCiclistaClase.IdCiclista.Value;
                            ciclistaClase.Ciclista.NombreCiclista = resultCiclistaClase.NombreCiclista;
                            ciclistaClase.Ciclista.Nivel = resultCiclistaClase.Nivel;
                            ciclistaClase.Clase = new ML.Clase();
                            ciclistaClase.Clase.IdClase = resultCiclistaClase.IdClase.Value;
                            ciclistaClase.Clase.NombreClase = resultCiclistaClase.NombreClase;

                            result.Objects.Add(ciclistaClase);
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
