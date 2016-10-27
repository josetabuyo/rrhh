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
    public class RepositorioDeContratos
    {
        private IConexionBD conexion_bd;
        private List<object> datos_bd;
        private static int id_area_anterior;
        private static string tipo_anterior;
        private static DateTime fecha_anterior;
        private static GraficoContratos GRAFICO_CONTRATO;
        private static bool incluir_dependencias_anterior;
        private static bool detalle_sueldo;

        public RepositorioDeContratos(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public GraficoContratos GetGraficoContratados(int id_area, bool incluir_dependencias)
        {
            GraficoContratos grafico = new GraficoContratos();

            
            if (GRAFICO_CONTRATO != null)
            {
                if (GRAFICO_CONTRATO.ContienePersonas())
                {
                    CrearResumen(GRAFICO_CONTRATO);
                }

                return GRAFICO_CONTRATO;
            }
           
           
            id_area_anterior = id_area;
            incluir_dependencias_anterior = incluir_dependencias;
            var parametros = new Dictionary<string, object>();

            parametros.Add("@id_area", id_area);
            parametros.Add("@incluir_dependencias", incluir_dependencias);
            var tablaDatos = conexion_bd.Ejecutar("dbo.GRAF_RPT_Dotacion", parametros);
            if (tablaDatos.Rows.Count > 0)
            {
                grafico.CrearDatos(tablaDatos.Rows);

            }
            if (grafico.ContienePersonas())
            {
                CrearResumen(grafico);
            }

            GRAFICO_CONTRATO = grafico;

            return grafico;

        }

        private void CrearResumen(Grafico grafico)
        {
            grafico.GraficoPorArea();
           
        }


        
        #region Archivos Excel


        public string ExcelGenerado(string tipo, int dia, int mes, int anio, bool incluir_dependencias, DateTime fecha, int id_area)
        {
            try
            {              
                Grafico grafico = GetGraficoContratados(id_area, incluir_dependencias);

                DataTable table_resumen = new DataTable();
                table_resumen.TableName = "Resumen";

                RepositorioDeAreas repositorio_de_areas = RepositorioDeAreas.NuevoRepositorioDeAreas(this.conexion_bd);
                Area area = repositorio_de_areas.GetAreaPorId(id_area);                
             
                table_resumen.Columns.Add("Informacion");
                table_resumen.Columns.Add("Cantidad");
                table_resumen.Columns.Add("Porcentaje");

                foreach (var item in grafico.tabla_resumen)
                {
                    table_resumen.Rows.Add(item.Id.Replace("|"," "), item.Cantidad, item.Porcentaje);
                }
                
                DataTable table_detalle = new DataTable();
                table_detalle.TableName = "Detalle";

                table_detalle.Columns.Add("NroDocumento");
                table_detalle.Columns.Add("Apellido");
                table_detalle.Columns.Add("Nombre");
                table_detalle.Columns.Add("Area");
                table_detalle.Columns.Add("Area Descrip Media");

                foreach (var item in grafico.tabla_detalle)
                {
                    table_detalle.Rows.Add(item.NroDocumento, item.Apellido, item.Nombre, item.Area, item.AreaDescripMedia);
                }

                //CREACIÓN DE LAS COLUMNAS
                //      table.Columns.Add("Categoria", typeof(string));
                //       table.Columns.Add("% Participación VM", typeof(double));

                var workbook = new XLWorkbook();

                //   var dataTable_consulta_parametros = table;
                var dataTable_resumen = table_resumen;
                var dataTable_detalle = table_detalle;
                var ws = workbook.Worksheets.Add("Resumen");

                ws.Style.Font.FontSize = 11;
                ws.Style.Font.FontName = "Verdana";

                ws.Column("A").Width = 15;
                ws.Column("B").Width = 15;
                ws.Column("C").Width = 15;

                //  ws.Row(1).Height = 25;
                //  ws.Row(1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                ws.Cell(1, 1).Value = "FECHA:";
                ws.Cell(2, 1).Value = "AREA:";

                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(2, 1).Style.Font.Bold = true;

                ws.Cell(1, 2).Value = fecha.ToShortDateString();
                ws.Cell(2, 2).Value = area.Nombre.ToUpper();

                ws.Range(4, 1, 4, 3).Style.Fill.BackgroundColor = XLColor.FromArgb(79, 129, 189);
                ws.Range(4, 1, 4, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                ws.Range(4, 1, 4, 3).Style.Font.FontColor = XLColor.White;

                ws.Cell(4, 1).Value = "Informacion";
                ws.Cell(4, 2).Value = "Cantidad";
                ws.Cell(4, 3).Value = "Porcentaje %";

                var rangeWithData = ws.Cell(5, 1).InsertData(dataTable_resumen.AsEnumerable());

                var lastCell = ws.LastCellUsed();

                ws.Range(4, 1, lastCell.Address.RowNumber, lastCell.Address.ColumnNumber).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                ws.Range(4, 1, lastCell.Address.RowNumber, lastCell.Address.ColumnNumber).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;

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
        

        #endregion


        
    }
}
