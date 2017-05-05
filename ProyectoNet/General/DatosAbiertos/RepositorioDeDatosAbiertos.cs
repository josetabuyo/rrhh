using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using System.Linq;
using System.Reflection;
using General.Repositorios;

namespace General.DatosAbiertos
{
    public class RepositorioDeDatosAbiertos
    {
        private IConexionBD conexion_bd;
        private List<object> datos_bd;
        private static int id_area_anterior;
        private static string tipo_anterior;
        private static DateTime fecha_anterior;
        private static GraficoSueldo GRAFICOSUELDO;
        private static GraficoDotacion GRAFICODOTACION;
        private static GraficoRangoEtario GRAFICORANGOETARIO;
        private static GraficoContratos GRAFICO_CONTRATO;
        private static bool incluir_dependencias_anterior;
        private static bool detalle_sueldo;

        public RepositorioDeDatosAbiertos(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public List<ConsultaOPD> getConsultas()
        {
            var consultas = new List<ConsultaOPD>();
            var tablaDatos = conexion_bd.Ejecutar("dbo.DATA_GetConsultas");
            if (tablaDatos.Rows.Count > 0)
            {
                ConsultaOPD una_consulta = new ConsultaOPD();
                //ParametroConsultaOPD un_parametro;

                tablaDatos.Rows.ForEach(row =>
                {
                    if (consultas.FindAll(t => t.Id == row.GetInt("IdConsulta")).Count == 0)
                    {
                        una_consulta = new ConsultaOPD();
                        una_consulta.Id = row.GetInt("IdConsulta");
                        una_consulta.Nombre = row.GetString("NombreConsulta");
                        una_consulta.Descripcion = row.GetString("DescripcionConsulta");
                        una_consulta.SP = row.GetString("SP");
                        una_consulta.Funcionalidad = row.GetInt("idFuncionalidad");

                        consultas.Add(una_consulta);
                    }
                //    if (row.GetInt("IdParametro", -1) >= 0)
                //    {
                //        un_parametro = new ParametroConsultaOPD();
                //        un_parametro.Id = row.GetInt("IdParametro");
                //        un_parametro.Nombre = row.GetString("NombreParametro");
                //        un_parametro.Valor = row.GetString("ValorParametro");
                //        un_parametro.Tipo = row.GetString("TipoParametro");

                //        una_consulta.Parametros.Add(un_parametro);
                //    }
                });
            }
            return consultas;
        }



        public string EjecutarConsultaOPD(int id_consulta)
        {
            try
            {
                var consulta = this.getConsultas().Find(c=> c.Id==id_consulta);
                var parametros = new Dictionary<string, object>();
                var tablaDatos = conexion_bd.Ejecutar(consulta.SP);

                DataTable tablaExcel = new DataTable();
                tablaExcel.TableName = consulta.Nombre;

                foreach (DataColumn dc in tablaDatos.Columns)
                {
                    tablaExcel.Columns.Add(dc.ColumnName);
                }

                tablaDatos.Rows.ForEach((row) =>
                {
                    var dr = tablaExcel.NewRow();
                    foreach (DataColumn dc in tablaDatos.Columns)
                    {
                        dr[dc.ColumnName] = row.GetTodoComoString(dc.ColumnName, "");
                    }

                    tablaExcel.Rows.Add(dr);
                });


                var workbook = new XLWorkbook();

                var dataTable_detalle = tablaExcel;
                workbook.Worksheets.Add(dataTable_detalle);


                using (var ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);

                    return Convert.ToBase64String(ms.ToArray());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        public string ExcelGeneradoMapaDelEstado()
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@FechaVigencia_Prot", DateTime.Now);
                parametros.Add("@Muestra_Depto_Prot ", 0);
                parametros.Add("@Muestra_Lugares_de_Trabajo_Prot  ", 0);
                parametros.Add("@Muestra_Lugares_Sin_Trabajadores_Prot   ", 0);
               // var tablaDatos = conexion_bd.Ejecutar("dbo.VIA_Get_AreasMapadelEstadoMDS", parametros);
                var tablaDatos = conexion_bd.Ejecutar("dbo.DATA_Mapa_del_EstadoMDS", parametros);
                             
                DataTable tablaExcel = new DataTable();
                tablaExcel.TableName = "Mapa_MDS";

                foreach (DataColumn dc in tablaDatos.Columns)
                {
                    tablaExcel.Columns.Add(dc.ColumnName);
                }

                tablaDatos.Rows.ForEach((row) =>
                {
                    var dr = tablaExcel.NewRow();
                    foreach (DataColumn dc in tablaDatos.Columns)
                    {
                        dr[dc.ColumnName] = row.GetTodoComoString(dc.ColumnName, "");
                    }

                    tablaExcel.Rows.Add(dr);
                });


                var workbook = new XLWorkbook();

                var dataTable_detalle = tablaExcel;
                workbook.Worksheets.Add(dataTable_detalle);


                using (var ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);

                    return Convert.ToBase64String(ms.ToArray());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public string ExcelPlanificacionDotaciones()
        {

            try
            {
                var parametros = new Dictionary<string, object>();
                //parametros.Add("@FechaVigencia_Prot", DateTime.Now);
                //parametros.Add("@Muestra_Depto_Prot ", 0);
                //parametros.Add("@Muestra_Lugares_de_Trabajo_Prot  ", 0);
                //parametros.Add("@Muestra_Lugares_Sin_Trabajadores_Prot   ", 0);
                // var tablaDatos = conexion_bd.Ejecutar("dbo.VIA_Get_AreasMapadelEstadoMDS", parametros);
               // var tablaDatos = conexion_bd.Ejecutar("dbo.DATA_ProgPlanifDotaciones", parametros);
                var tablaDatos = conexion_bd.Ejecutar("dbo.DATA_ProgPlanifDotaciones",90);

                DataTable tablaExcel = new DataTable();
                tablaExcel.TableName = "Planif_Dotaciones";

                foreach (DataColumn dc in tablaDatos.Columns)
                {
                    tablaExcel.Columns.Add(dc.ColumnName);
                }

                tablaDatos.Rows.ForEach((row) =>
                {
                    var dr = tablaExcel.NewRow();
                    foreach (DataColumn dc in tablaDatos.Columns)
                    {
                        dr[dc.ColumnName] = row.GetTodoComoString(dc.ColumnName, "");
                    }

                    tablaExcel.Rows.Add(dr);
                });

                var workbook = new XLWorkbook();

                var dataTable_detalle = tablaExcel;

                workbook.Worksheets.Add(dataTable_detalle);

                using (var ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);

                    return Convert.ToBase64String(ms.ToArray());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        
        
        }
    }
}
