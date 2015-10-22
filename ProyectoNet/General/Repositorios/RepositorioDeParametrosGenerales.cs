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
    }
}
