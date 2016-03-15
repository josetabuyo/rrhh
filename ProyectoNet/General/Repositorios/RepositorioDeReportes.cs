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
        private static int id_area_anterior;
        private static int tipo_anterior;
        private static DateTime fecha_anterior;
        private static Grafico grafico = new Grafico();

        public RepositorioDeReportes(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }


        public Grafico GetGraficoDotacion(int tipo, DateTime fecha, int id_area)
        {
            if (fecha.Year == fecha_anterior.Year && fecha.Month == fecha_anterior.Month && fecha.Day == fecha_anterior.Day && id_area == id_area_anterior)
            {

                    CrearResumen(tipo);

                return grafico;

            }
            tipo_anterior = tipo;
            fecha_anterior = fecha;
            id_area_anterior = id_area;
            var parametros = new Dictionary<string, object>();

            parametros.Add("@fechacorte", fecha);
            parametros.Add("@id_area", id_area);
            var tablaDatos = conexion_bd.Ejecutar("dbo.GRAF_RPT_Dotacion", parametros);
            if (tablaDatos.Rows.Count > 0)
            {
                grafico.CrearDatos(tablaDatos.Rows);

            }

            CrearResumen(tipo);

            return grafico;

        }

        private static void CrearResumen(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    grafico.GraficoPorGenero();
                    break;
                case 2:
                    grafico.GraficoPorNivel();
                    break;
                case 3:
                    grafico.GraficoPorEstudio();
                    break;
                case 4:
                    grafico.GraficoPorPlanta();
                    break;
                case 5:
                    grafico.GraficoPorAfiliacionGremial();
                    break;
            }
        }


    }
}
