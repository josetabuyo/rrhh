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
                    //List<Area> areas = BuscarAreas();
                    grafico.GraficoPorArea();
                    break;
                case 6:
                    //List<Area> areas = BuscarAreas();
                    grafico.GraficoPorSecretarias();
                    break;
                case 7:
                    //List<Area> areas = BuscarAreas();
                    grafico.GraficoPorSubSecretarias();
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



        public List<SueldoPersona> GetReporteSueldosPorArea(DateTime fecha, int id_area, bool incluir_dependencias)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@fechacorte", fecha);
            parametros.Add("@id_area", id_area);
            parametros.Add("@incluir_dependencias", incluir_dependencias);
            var tablaDatos = conexion_bd.Ejecutar("dbo.GRAF_RPT_Dotacion_Sueldos", parametros);

            var lista_sueldos = new List<SueldoPersona>();

            tablaDatos.Rows.ForEach(row =>
            {
                var persona = new SueldoPersona();
                persona.idPersona = row.GetInt("id_persona", 0);
                persona.legajo = row.GetInt("legajo", 0);
                persona.nroDocumento = row.GetInt("nro_documento", 0);
                persona.apellido = row.GetString("apellido", "Sin Dato");
                persona.nombre = row.GetString("nombre", "Sin Dato");
                persona.area = row.GetString("area", "Sin Dato");
                persona.areaDescripCorta = row.GetString("area_descrip_corta", "Sin Dato");
                persona.areaDescripMedia = row.GetString("area_descrip_media", "Sin Dato");
                persona.sueldoAnio = row.GetSmallintAsInt("SueldoAnio", 0);
                persona.sueldoMes = row.GetSmallintAsInt("SueldoMes", 0);
                persona.sueldoBruto = row.GetFloat("SueldoBruto", 0);
                persona.sueldoNeto = row.GetFloat("SueldoNeto", 0);
                persona.xtrasAnio = row.GetSmallintAsInt("XtrasAnio", 0);
                persona.xtrasMes = row.GetSmallintAsInt("XtrasMes", 0);
                persona.xtrasBruto = row.GetFloat("XtrasBruto", 0);
                persona.xtrasNeto = row.GetFloat("XtrasNeto", 0);
                persona.SACAnio = row.GetInt("SACAnio", 0);
                persona.SACMes = row.GetInt("SACMes", 0);
                persona.SACBruto = row.GetFloat("SACBruto", 0);
                persona.SACNeto = row.GetFloat("SACNeto", 0);
                persona.hsSimples = row.GetSmallintAsInt("HsSimples", 0);
                persona.hs50 = row.GetSmallintAsInt("Hs50", 0);
                persona.hs100 = row.GetSmallintAsInt("Hs100", 0);
                persona.comidas = row.GetSmallintAsInt("Comidas", 0);

                lista_sueldos.Add(persona);
            });
            return lista_sueldos;
        }
    }
}
