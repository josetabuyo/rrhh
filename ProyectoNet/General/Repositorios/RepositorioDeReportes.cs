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
    public class RepositorioDeReportes
    {
        private IConexionBD conexion_bd;
        private List<object> datos_bd;
        private static int id_area_anterior;
        private static string tipo_anterior;
        private static DateTime fecha_anterior;
        private static GraficoSueldo GRAFICOSUELDO;
        private static bool incluir_dependencias_anterior;
        private static bool detalle_sueldo;

        public RepositorioDeReportes(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }
        
        public Grafico GetGraficoDotacion(GraficoDotacion grafico, string tipo, DateTime fecha, int id_area, bool incluir_dependencias)
        {
            
            if (fecha.Year == fecha_anterior.Year && fecha.Month == fecha_anterior.Month && fecha.Day == fecha_anterior.Day && id_area == id_area_anterior && incluir_dependencias == incluir_dependencias_anterior && !detalle_sueldo)
            {

                if (grafico.ContienePersonas())
                {
                    CrearResumen(grafico, tipo, fecha);
                }

                return grafico;

            }
            detalle_sueldo = false;
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
                CrearResumen(grafico, tipo, fecha);
            }

            

            return grafico;

        }

        private void CrearResumen(Grafico grafico, string tipo, DateTime fecha)
        {

            //Type magicType = Type.GetType(grafico.GetType().FullName);
            //ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
            //object magicClassObject = magicConstructor.Invoke(new object[] { });
            MethodInfo magicMethod = grafico.GetType().GetMethod(tipo);// magicType.GetMethod("GraficoPorArea");
            magicMethod.Invoke(grafico, new object[] { });

            /*switch (tipo)
            {
                case 1:
                    
                    grafico.GraficoPorGenero();
                    break;
                case 2:
                    List<string> niveles = getNiveles();
                    grafico.GraficoPorNivel(niveles);
                    break;
                case 3:
                    grafico.GraficoPorEstudio();
                    break;
                case 4:
                    Dictionary<int, string> plantas = getTipoPlanta();
                    grafico.GraficoPorPlanta(plantas);
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
                    grafico.GraficoPorArea();
                    break;
                case 9:
                    grafico.GraficoPorSecretarias();
                    break;
                case 10:
                    grafico.GraficoPorSubSecretarias();
                    break;
                //    grafico.GraficoPorAfiliacionGremial();
                //    break;
                //case 6:
                //    grafico.GraficoRangoEtareo(fecha);
                //    break;
            }*/
        }

        //private static List<Area> BuscarAreas()
        //{
        //    throw new NotImplementedException();
        //}

        public GraficoSueldo GetReporteSueldosPorArea(string tipo, DateTime fecha, int id_area, bool incluir_dependencias)
        {

            GraficoSueldo grafico = new GraficoSueldo();

            //if (tipo == 0) tipo = 10;

            if (fecha.Year == fecha_anterior.Year && fecha.Month == fecha_anterior.Month && fecha.Day == fecha_anterior.Day && id_area == id_area_anterior && incluir_dependencias == incluir_dependencias_anterior && detalle_sueldo)
            {

                if (GRAFICOSUELDO.ContienePersonas())
                {
                    CrearResumen(GRAFICOSUELDO, tipo, fecha);
                }

                return grafico;
            }
            detalle_sueldo = true;
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
                CrearResumen(grafico, tipo, fecha);
            }

            GRAFICOSUELDO = grafico;
            return grafico;

        }


        private List<string> getNiveles()
        {
            var parametros = new Dictionary<string, object>();
            var tablaDatos = conexion_bd.Ejecutar("dbo.GRAF_GET_Niveles", parametros);
            List<string> listaNiveles = new List<string>();


            tablaDatos.Rows.ForEach(nivel => listaNiveles.Add(nivel.GetString("Nivel","Sin dato").ToString()));


            return listaNiveles;
        }

        private Dictionary<int, string> getTipoPlanta()
        {
            var parametros = new Dictionary<string, object>();
            var tablaDatos = conexion_bd.Ejecutar("dbo.GEN_GET_Tipo_Planta", parametros);
            //List<int> listaTipoPlanta = new List<int>();
            Dictionary<int, string> listaPlanta = new Dictionary<int, string>();

            tablaDatos.Rows.ForEach(plan => listaPlanta.Add(plan.GetSmallintAsInt("id", 0), plan.GetString("descripcion", "No Especifica")));


            return listaPlanta;
        }


        #region Archivos Excel

        public string ExcelGeneradoSueldos(GraficoSueldo grafico, string tipo, int dia, int mes, int anio, bool incluir_dependencias, int id_area)
        {
            try
            {
                DateTime fecha = new DateTime(anio, mes, dia);
                RepositorioDeAreas repositorio_de_areas = RepositorioDeAreas.NuevoRepositorioDeAreas(this.conexion_bd);
                Grafico graficoExcel = GetReporteSueldosPorArea(tipo, fecha, id_area, incluir_dependencias);
                // return repositorio.GetReporteSueldosPorArea(fecha, id_area, incluir_dependencias);

                DataTable table_resumen = new DataTable();
                table_resumen.TableName = "Detalle";

                DataTable table_detalle = new DataTable();
                table_detalle.TableName = "Sueldos";

                Area area = repositorio_de_areas.GetAreaPorId(id_area);

                table_detalle.Columns.Add("Informacion");
                table_detalle.Columns.Add("Cantidad");
                table_detalle.Columns.Add("Porcentaje (%)");
                table_detalle.Columns.Add("SumatoriaSueldo");
                table_detalle.Columns.Add("PromedioSueldo");
                table_detalle.Columns.Add("MedianaSueldo");
                table_detalle.Columns.Add("SumatoriaExtras");
                table_detalle.Columns.Add("PromedioExtras");
                table_detalle.Columns.Add("MedianaExtras");

                foreach (var item in graficoExcel.tabla_resumen)
                {
                    table_detalle.Rows.Add(item.Id,
                        item.Cantidad,
                        Math.Truncate(item.Porcentaje * 100) / 100,
                        item.SumatoriaSueldo,
                        item.PrimedioSueldo,
                        item.MedianaSueldo,
                        item.SumatoriaExtras,
                        item.PrimedioExtras,
                        item.MedianaExtras);
                }

                table_resumen.Columns.Add("Area");
                table_resumen.Columns.Add("Documento");
                table_resumen.Columns.Add("Apellido");
                table_resumen.Columns.Add("Nombre");
                table_resumen.Columns.Add("SueldoBruto");
                table_resumen.Columns.Add("SueldoNeto");
                table_resumen.Columns.Add("ExtrasBruto");
                table_resumen.Columns.Add("ExtrasNeto");
                table_resumen.Columns.Add("HsSimples");
                table_resumen.Columns.Add("Hs50%");
                table_resumen.Columns.Add("Hs100%");
                table_resumen.Columns.Add("Comidas");
                table_resumen.Columns.Add("UR");
                foreach (var item in grafico.tabla_detalle)
                {
                    object valor_extra_bruto = null;
                    if (item.ExtrasBruto != 0)
                    {
                        valor_extra_bruto = item.ExtrasBruto;
                        //table_resumen.Rows.Add(item.AreaDescripCorta, item.NroDocumento, item.Apellido, item.Nombre, item.SueldoBruto, item.SueldoNeto, item.ExtrasBruto, item.ExtrasNeto, item.HsSimples, item.Hs50, item.Hs100, item.Comidas);
                    }
                    object valor_extra_neto = null;
                    if (item.ExtrasNeto != 0)
                    {
                        valor_extra_neto = item.ExtrasNeto;
                    }

                    object valor_horas_simples = null;
                    if (item.HsSimples != 0)
                    {
                        valor_horas_simples = item.HsSimples;
                    }

                    object valor_horas_50 = null;
                    if (item.Hs50 != 0)
                    {
                        valor_horas_50 = item.Hs50;
                    }
                    object valor_horas_100 = null;
                    if (item.Hs100 != 0)
                    {
                        valor_horas_100 = item.Hs100;
                    }
                    object valor_comidas = null;
                    if (item.Hs100 != 0)
                    {
                        valor_comidas = item.Comidas;
                    }
                    object valor_UR = null;
                    if (item.UnidadRetributiva != 0)
                    {
                        valor_UR = item.UnidadRetributiva;
                    }
                    table_resumen.Rows.Add(item.Area, item.NroDocumento, item.Apellido, item.Nombre, item.SueldoBruto, item.SueldoNeto, valor_extra_bruto, valor_extra_neto, valor_horas_simples, valor_horas_50, valor_horas_100, valor_comidas, valor_UR);
                }

                var workbook = new XLWorkbook();
                //var dataTable_consulta_parametros = table;
                var dataTable_resumen = table_resumen;
                var dataTable_detalle = table_detalle;
                var ws = workbook.Worksheets.Add("Resumen");

                ws.Style.Font.FontSize = 11;
                ws.Style.Font.FontName = "Verdana";

                ws.Column("A").Width = 15;
                ws.Column("B").Width = 15;
                ws.Column("C").Width = 25;
                ws.Column("D").Width = 25;
                ws.Column("E").Width = 18;
                ws.Column("F").Width = 18;
                ws.Column("G").Width = 18;
                ws.Column("H").Width = 18;
                ws.Column("I").Width = 18;
                ws.Column("J").Width = 18;
                ws.Column("K").Width = 18;
                ws.Column("L").Width = 18;
                ws.Column("M").Width = 18;

                //  ws.Row(1).Height = 25;
                //  ws.Row(1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                ws.Cell(1, 1).Value = "FECHA:";
                ws.Cell(2, 1).Value = "AREA:";

                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(2, 1).Style.Font.Bold = true;

                ws.Cell(1, 2).Value = fecha.ToShortDateString();
                ws.Cell(2, 2).Value = area.Nombre.ToUpper();

                ws.Range(4, 1, 4, 9).Style.Fill.BackgroundColor = XLColor.FromArgb(79, 129, 189);
                ws.Range(4, 1, 4, 9).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                ws.Range(4, 1, 4, 9).Style.Font.FontColor = XLColor.White;


                ws.Cell(4, 1).Value = "Informacion";
                ws.Cell(4, 2).Value = "Cantidad";
                ws.Cell(4, 3).Value = "Porcentaje %";
                ws.Cell(4, 4).Value = "SumatoriaSueldo";
                ws.Cell(4, 5).Value = "PromedioSueldo";
                ws.Cell(4, 6).Value = "MedianaSueldo";
                ws.Cell(4, 7).Value = "SumatoriaExtras";
                ws.Cell(4, 8).Value = "PromedioExtras";
                ws.Cell(4, 9).Value = "MedianaExtras";
                //   ws.Cell(4, 10).Value = "HS 50%";
                //    ws.Cell(4, 11).Value = "HS 100%";
                //    ws.Cell(4, 12).Value = "COMIDAS";
                //  ws.Cell(4, 1).Value = "Informacion";
                //  ws.Cell(4, 2).Value = "Cantidad";
                //  ws.Cell(4, 3).Value = "Porcentaje %";

                var rangeWithData = ws.Cell(5, 1).InsertData(dataTable_detalle.AsEnumerable());

                var lastCell = ws.LastCellUsed();

                ws.Range(4, 1, lastCell.Address.RowNumber, lastCell.Address.ColumnNumber).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                ws.Range(4, 1, lastCell.Address.RowNumber, lastCell.Address.ColumnNumber).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;

                //ws.Range(5, 2, lastCell.Address.RowNumber, 2).DataType=XLCellValues.Number;
                ws.Range(5, 2, lastCell.Address.RowNumber, lastCell.Address.ColumnNumber).DataType = XLCellValues.Number;

                workbook.Worksheets.Add(dataTable_resumen);

                var lastCell2 = workbook.Worksheet(2).LastCellUsed();
                workbook.Worksheet(2).Range(2, 2, lastCell2.Address.RowNumber, 2).DataType = XLCellValues.Number;
                workbook.Worksheet(2).Range(2, 5, lastCell2.Address.RowNumber, 13).DataType = XLCellValues.Number;

                workbook.Worksheet(2).Column("A").Width = 25;
                workbook.Worksheet(2).Column("B").Width = 14;
                workbook.Worksheet(2).Column("C").Width = 25;
                workbook.Worksheet(2).Column("D").Width = 25;
                workbook.Worksheet(2).Column("E").Width = 18;
                workbook.Worksheet(2).Column("F").Width = 18;
                workbook.Worksheet(2).Column("G").Width = 18;
                workbook.Worksheet(2).Column("H").Width = 18;
                workbook.Worksheet(2).Column("I").Width = 18;
                workbook.Worksheet(2).Column("J").Width = 18;
                workbook.Worksheet(2).Column("K").Width = 18;
                workbook.Worksheet(2).Column("L").Width = 18;
                workbook.Worksheet(2).Column("M").Width = 18;

                //  string rut = HttpContext.Current.Request.PhysicalApplicationPath + "/Excel.xlsx";

                using (var ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);

                    // return ms.ToArray();

                    //return File(ms.ToArray(), MediaTypeNames.Application.Octet, "excel2"+ ".xlsx");
                    return Convert.ToBase64String(ms.ToArray());
                }


                //
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }





        #endregion





    }
}
