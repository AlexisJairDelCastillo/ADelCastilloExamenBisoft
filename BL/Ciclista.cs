using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Ciclista
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AdelCastilloExamenBisoContext context = new DL.AdelCastilloExamenBisoContext())
                {
                    var query = context.Ciclista.FromSqlRaw("CiclistaGetAll").ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DL.Ciclistum resultCiclista in query)
                        {
                            ML.Ciclista ciclista = new ML.Ciclista();
                            ciclista.IdCiclista = resultCiclista.IdCiclista;
                            ciclista.NombreCiclista = resultCiclista.NombreCiclista;
                            ciclista.Direccion = resultCiclista.Direccion;
                            ciclista.Edad = resultCiclista.Edaad;
                            ciclista.Nivel = resultCiclista.Nivel;
                            ciclista.MembresiaActiva = resultCiclista.MembresiaActiva;

                            result.Objects.Add(ciclista);
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

        public static ML.Result GetById(int idCiclista)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AdelCastilloExamenBisoContext context = new DL.AdelCastilloExamenBisoContext())
                {
                    var query = context.Ciclista.FromSqlRaw($"CiclistaGetById {idCiclista}").AsEnumerable().FirstOrDefault();

                    if(query != null)
                    {
                        ML.Ciclista ciclista = new ML.Ciclista();
                        ciclista.IdCiclista = query.IdCiclista;
                        ciclista.NombreCiclista = query.NombreCiclista;
                        ciclista.Direccion = query.Direccion;
                        ciclista.Edad = query.Edaad;
                        ciclista.Nivel = query.Nivel;
                        ciclista.MembresiaActiva = query.MembresiaActiva;

                        result.Object = ciclista;
                        result.Correct = true;
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar el registro." + ex.Message;
            }

            return result;
        }

        public static ML.Result Add(ML.Ciclista ciclista)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AdelCastilloExamenBisoContext context = new DL.AdelCastilloExamenBisoContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"CiclistaAdd '{ciclista.NombreCiclista}', '{ciclista.Direccion}', {ciclista.Edad}, '{ciclista.Nivel}', {ciclista.MembresiaActiva}");

                    if(query > 0)
                    {
                        result.Correct = true;
                        result.Message = "El registro se inserto correctamente.";
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el registro." + ex.Message;
            }

            return result;
        }

        public static ML.Result Update(ML.Ciclista ciclista)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.AdelCastilloExamenBisoContext context = new DL.AdelCastilloExamenBisoContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"CiclistaUpdate {ciclista.IdCiclista}, '{ciclista.NombreCiclista}', '{ciclista.Direccion}', {ciclista.Edad}, '{ciclista.Nivel}', {ciclista.MembresiaActiva}");

                    if(query > 0)
                    {
                        result.Correct = true;
                        result.Message = "El registro se actualizo correctamente.";
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar el registro." + ex.Message;
            }

            return result;
        }
    }
}
