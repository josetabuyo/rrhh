using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace WebRhUI
{
    public class RenderizadorDeTablas<T>
    {
        private EntityToRowConverter<T> converter;

        public String EstiloCeldaCabecera { get; set; }

        private List<string> EstiloCeldasCuerpo { get; set; }

        public String EstiloCeldaCuerpo { get; set; }

        public RenderizadorDeTablas(EntityToRowConverter<T> entity_converter)
        {
            this.converter = entity_converter;
        }

        public void AgregarCabeceras(string[] cabeceras, Table una_tabla)
        {
            TableRow row_cabeceras = new TableRow();
            foreach (var texto_de_cabecera in cabeceras)
            {
                AgregarCelda(row_cabeceras, texto_de_cabecera, EstiloCeldaCabecera);
            }
            una_tabla.Rows.Add(row_cabeceras);
        }

        private static void AgregarCelda(TableRow row, object contenido_de_la_celda, string estilo)
        {
            TableCell cell = new TableCell();
            cell.Text = (string)contenido_de_la_celda;
            cell.CssClass = estilo;
            row.Cells.Add(cell);
        }

        public void AddRowFrom(T una_entidad, Table tabla)
        {
            List<object> values = converter.Serialize(una_entidad);
            TableRow row_entidad = new TableRow();
            foreach (var value in values)
            {
                var estilo = EstiloCeldaCuerpo;
                if (EstiloCeldasCuerpo != null) estilo = EstiloCeldasCuerpo[values.IndexOf(value)];
                
                AgregarCelda(row_entidad, value, estilo);
            }
            tabla.Rows.Add(row_entidad);
        }

        public void RenderTo(List<T> entidades, Table tabla)
        {
            foreach (var entidad in entidades)
            {
                AddRowFrom(entidad, tabla);
            }
        }

        public void AgregarCssCeldas(List<string> list)
        {
            this.EstiloCeldasCuerpo = list;
        }        
    }
}
