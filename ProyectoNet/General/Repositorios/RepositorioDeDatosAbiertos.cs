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

namespace General.Repositorios
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

                //CREACIÓN DE LAS COLUMNAS
                //      table.Columns.Add("Categoria", typeof(string));
                //       table.Columns.Add("% Participación VM", typeof(double));

                var workbook = new XLWorkbook();

                var dataTable_detalle = tablaExcel;
                //var ws = workbook.Worksheets.Add("Resumen");

                //ws.Style.Font.FontSize = 11;
                //ws.Style.Font.FontName = "Verdana";

                //ws.Column("A").Width = 15;
                //ws.Column("B").Width = 15;
                //ws.Column("C").Width = 15;

                ////  ws.Row(1).Height = 25;
                ////  ws.Row(1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                //ws.Cell(1, 1).Value = "FECHA:";
                //ws.Cell(2, 1).Value = "AREA:";

                //ws.Cell(1, 1).Style.Font.Bold = true;
                //ws.Cell(2, 1).Style.Font.Bold = true;

                ////ws.Cell(1, 2).Value = fecha.ToShortDateString();
                ////ws.Cell(2, 2).Value = area.Nombre.ToUpper();

                //ws.Range(4, 1, 4, 3).Style.Fill.BackgroundColor = XLColor.FromArgb(79, 129, 189);
                //ws.Range(4, 1, 4, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                //ws.Range(4, 1, 4, 3).Style.Font.FontColor = XLColor.White;

                //ws.Cell(4, 1).Value = "Informacion";
                //ws.Cell(4, 2).Value = "Cantidad";
                //ws.Cell(4, 3).Value = "Porcentaje %";

                ////var rangeWithData = ws.Cell(5, 1).InsertData(dataTable_resumen.AsEnumerable());

                //var lastCell = ws.LastCellUsed();

                //ws.Range(4, 1, lastCell.Address.RowNumber, lastCell.Address.ColumnNumber).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                //ws.Range(4, 1, lastCell.Address.RowNumber, lastCell.Address.ColumnNumber).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;

                workbook.Worksheets.Add(dataTable_detalle);

                //  string rut = HttpContext.Current.Request.PhysicalApplicationPath + "/Excel.xlsx";

                using (var ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);

                    // return ms.ToArray();

                    //return File(ms.ToArray(), MediaTypeNames.Application.Octet, "excel2"+ ".xlsx");
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

                //CREACIÓN DE LAS COLUMNAS
                //      table.Columns.Add("Categoria", typeof(string));
                //       table.Columns.Add("% Participación VM", typeof(double));

                var workbook = new XLWorkbook();

                var dataTable_detalle = tablaExcel;
                //var ws = workbook.Worksheets.Add("Resumen");

                //ws.Style.Font.FontSize = 11;
                //ws.Style.Font.FontName = "Verdana";

                //ws.Column("A").Width = 15;
                //ws.Column("B").Width = 15;
                //ws.Column("C").Width = 15;

                ////  ws.Row(1).Height = 25;
                ////  ws.Row(1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                //ws.Cell(1, 1).Value = "FECHA:";
                //ws.Cell(2, 1).Value = "AREA:";

                //ws.Cell(1, 1).Style.Font.Bold = true;
                //ws.Cell(2, 1).Style.Font.Bold = true;

                ////ws.Cell(1, 2).Value = fecha.ToShortDateString();
                ////ws.Cell(2, 2).Value = area.Nombre.ToUpper();

                //ws.Range(4, 1, 4, 3).Style.Fill.BackgroundColor = XLColor.FromArgb(79, 129, 189);
                //ws.Range(4, 1, 4, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                //ws.Range(4, 1, 4, 3).Style.Font.FontColor = XLColor.White;

                //ws.Cell(4, 1).Value = "Informacion";
                //ws.Cell(4, 2).Value = "Cantidad";
                //ws.Cell(4, 3).Value = "Porcentaje %";

                ////var rangeWithData = ws.Cell(5, 1).InsertData(dataTable_resumen.AsEnumerable());

                //var lastCell = ws.LastCellUsed();

                //ws.Range(4, 1, lastCell.Address.RowNumber, lastCell.Address.ColumnNumber).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                //ws.Range(4, 1, lastCell.Address.RowNumber, lastCell.Address.ColumnNumber).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;

                workbook.Worksheets.Add(dataTable_detalle);

                //  string rut = HttpContext.Current.Request.PhysicalApplicationPath + "/Excel.xlsx";

                using (var ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);

                    // return ms.ToArray();

                    //return File(ms.ToArray(), MediaTypeNames.Application.Octet, "excel2"+ ".xlsx");
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
