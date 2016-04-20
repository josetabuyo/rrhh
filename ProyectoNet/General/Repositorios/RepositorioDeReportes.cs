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
        private static bool incluir_dependencias_anterior;

        public RepositorioDeReportes(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }


        public Grafico GetGraficoDotacion(int tipo, DateTime fecha, int id_area, bool incluir_dependencias)
        {
            if (fecha.Year == fecha_anterior.Year && fecha.Month == fecha_anterior.Month && fecha.Day == fecha_anterior.Day && id_area == id_area_anterior && incluir_dependencias == incluir_dependencias_anterior)
            {

                if (grafico.ContienePersonas())
                {
                    CrearResumen(tipo, fecha);
                }

                return grafico;

            }
            tipo_anterior = tipo;
            fecha_anterior = fecha;
            id_area_anterior = id_area;
            incluir_dependencias_anterior = incluir_dependencias;
            var parametros = new Dictionary<string, object>();

            parametros.Add("@fechacorte", fecha);
            parametros.Add("@id_area", id_area);
            parametros.Add("@incluir_dependencias", incluir_dependencias);
            var tablaDatos = conexion_bd.Ejecutar("dbo.GRAF_RPT_Dotacion", parametros);
            if (tablaDatos.Rows.Count > 0)
            {
                grafico.CrearDatos(tablaDatos.Rows);

            }
            if (grafico.ContienePersonas())
            {
                CrearResumen(tipo, fecha);
            }


            return grafico;

        }

        private static void CrearResumen(int tipo, DateTime fecha)
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
                    grafico.GraficoPorArea();
                    break;
                case 6:
                    grafico.GraficoPorSecretarias();
                    break;
                case 7:
                    grafico.GraficoPorSubSecretarias();
                    break;
                case 8:
                    grafico.GraficoDeSueldoPorArea();
                    break;
                case 9:
                    grafico.GraficoDeSueldoPorSecretarias();
                    break;
                case 10:
                    grafico.GraficoDeSueldoPorSubSecretarias();
                    break;
                //    grafico.GraficoPorAfiliacionGremial();
                //    break;
                //case 6:
                //    grafico.GraficoRangoEtareo(fecha);
                //    break;
            }
        }

        //private static List<Area> BuscarAreas()
        //{
        //    throw new NotImplementedException();
        //}



        public Grafico GetReporteSueldosPorArea(int tipo, DateTime fecha, int id_area, bool incluir_dependencias)
        {
            if (tipo == 0) tipo = 10;

            if (fecha.Year == fecha_anterior.Year && fecha.Month == fecha_anterior.Month && fecha.Day == fecha_anterior.Day && id_area == id_area_anterior && incluir_dependencias == incluir_dependencias_anterior)
            {

                if (grafico.ContienePersonas())
                {
                    CrearResumen(tipo, fecha);
                }

                return grafico;
            }
            tipo_anterior = tipo;
            fecha_anterior = fecha;
            id_area_anterior = id_area;
            incluir_dependencias_anterior = incluir_dependencias;
            var parametros = new Dictionary<string, object>();
            parametros.Add("@fechacorte", fecha);
            parametros.Add("@id_area", id_area);
            parametros.Add("@incluir_dependencias", incluir_dependencias);
            var tablaDatos = conexion_bd.Ejecutar("dbo.GRAF_RPT_Dotacion_Sueldos", parametros);


            if (tablaDatos.Rows.Count > 0)
            {
                grafico.CrearDatos(tablaDatos.Rows);
            }
            if (grafico.ContienePersonas())
            {
                CrearResumen(tipo, fecha);
            }
            return grafico;

        }
    }
}
