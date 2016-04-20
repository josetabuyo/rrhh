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

            var lista_sueldos = new List<Dotacion>();

            tablaDatos.Rows.ForEach(row =>
            {
                var persona = new Dotacion();
                persona.IdPersona = row.GetInt("id_persona", 0);
                persona.Legajo = row.GetInt("legajo", 0);
                persona.NroDocumento = row.GetInt("nrodocumento", 0);
                persona.Apellido = row.GetString("apellido", "Sin Dato");
                persona.Nombre = row.GetString("nombre", "Sin Dato");
                persona.IdArea = row.GetInt("id_area", 0);
                persona.AreaDescripCorta = row.GetString("area_descrip_corta", "Sin Dato");
                persona.IdSecretaria = row.GetInt("IdSecretaria", 0);
                persona.NombreSecretaria = row.GetString("area_descrip_secretaria", "Sin Dato");
                persona.IdSubSecretaria = row.GetInt("IdSubsecretaria", 0);
                persona.NombresubSecretaria = row.GetString("area_descrip_subsecretaria", "Sin Dato");
                persona.OrdenArea = row.GetSmallintAsInt("Orden", 0);
                persona.SueldoAnio = row.GetSmallintAsInt("SueldoAnio", 0);
                persona.SueldoMes = row.GetSmallintAsInt("SueldoMes", 0);
                persona.SueldoBruto = row.GetFloat("SueldoBruto", 0);
                persona.SueldoNeto = row.GetFloat("SueldoNeto", 0);
                persona.ExtrasAnio = row.GetSmallintAsInt("XtrasAnio", 0);
                persona.ExtrasMes = row.GetSmallintAsInt("XtrasMes", 0);
                persona.ExtrasBruto = row.GetFloat("XtrasBruto", 0);
                persona.ExtrasNeto = row.GetFloat("XtrasNeto", 0);
                persona.SACAnio = row.GetInt("SACAnio", 0);
                persona.SACMes = row.GetInt("SACMes", 0);
                persona.SACBruto = row.GetFloat("SACBruto", 0);
                persona.SACNeto = row.GetFloat("SACNeto", 0);
                persona.HsSimples = row.GetSmallintAsInt("HsSimples", 0);
                persona.Hs50 = row.GetSmallintAsInt("Hs50", 0);
                persona.Hs100 = row.GetSmallintAsInt("Hs100", 0);
                persona.HsTotalesSimples(persona.HsSimples, persona.Hs50, persona.Hs100);
                persona.Comidas = row.GetSmallintAsInt("Comidas", 0);

                lista_sueldos.Add(persona);
            });
            grafico.tabla_detalle = lista_sueldos;
            return grafico;
        }
    }
}
