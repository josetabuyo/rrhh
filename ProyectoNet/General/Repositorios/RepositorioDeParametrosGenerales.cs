using System.Collections.Generic;
using System;
using General.MAU;

namespace General.Repositorios
{
    public class RepositorioDeParametrosGenerales
    {
        public IConexionBD conexion_bd { get; set; }

        public RepositorioDeParametrosGenerales(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public string GetLeyendaAnio(int anio)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Anio", anio);
            return (string)conexion_bd.EjecutarEscalar("dbo.GEN_GetLeyendaAnio", parametros);
        }

        public string GetAnioDeContrato()
        {
            //var parametros = new Dictionary<string, object>();
            //parametros.Add("@Anio", anio);
            return (string)conexion_bd.EjecutarEscalar("dbo.GEN_GetAnioRenovacionContrato");
        }

        public List<DateTime> GetFeriados()
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Anio", DateTime.Now.Year);
            //parametros.Add("@mes", mes);
            var tablaDatos = conexion_bd.Ejecutar("dbo.GEN_Get_Feriados", parametros);

            var fechas = new List<DateTime>();
            tablaDatos.Rows.ForEach(row =>
            {
                fechas.Add(row.GetDateTime("Fecha"));
            });

            return fechas;
        }
    }
}
