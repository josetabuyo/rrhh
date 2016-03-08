using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioDeReportes 
    {
         private IConexionBD conexion_bd;
        private List<object> datos_bd;
        private int id_area_anterior;
        private DateTime fecha_anterior;

         public RepositorioDeReportes(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }


         public Grafico GetGraficoDotacion(int tipo, DateTime fecha, int id_area)
        {
             var parametros = new Dictionary<string, object>();
             Grafico grafico = new Grafico();
            parametros.Add("@fechacorte", fecha);
            parametros.Add("@id_area", id_area);
            var tablaDatos = conexion_bd.Ejecutar("dbo.GRAF_RPT_Dotacion", parametros);
            if (tablaDatos.Rows.Count > 0) {
                grafico.CrearDatos(tipo, tablaDatos.Rows);
            }
            
            
            if (fecha == fecha_anterior && id_area == id_area_anterior)
            {
                
            }
            return grafico;
            
        }

       
    }
}
