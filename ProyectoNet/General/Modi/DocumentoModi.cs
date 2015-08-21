using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Modi
{
    public class DocumentoModi
    {
        public string descripcionEnRRHH { get; set; }
        public string jurisdiccion { get; set; }
        public string organismo { get; set; }
        public DateTime fechaDesde { get; set; }
        public string tabla { get; set; }
        public int id { get; set; }
        public int idCategoria { get; set; }
        public List<FolioModi> folios{get; set;}

        public DocumentoModi()
        {
            this.folios = new List<FolioModi>();
        }
        public DocumentoModi(  string una_tabla,
                                int un_id,
                                string unaDescripcion, 
                                string una_jurisdiccion, 
                                string un_organismo,
                                string rango_folios, 
                                DateTime una_fecha_desde )
        {
            this.descripcionEnRRHH = unaDescripcion;
            this.jurisdiccion = una_jurisdiccion;
            this.organismo = un_organismo;
            this.fechaDesde = una_fecha_desde;
            this.tabla = una_tabla;
            this.id = un_id;
            this.folios = new List<FolioModi>();

            var folio_desde = int.Parse(rango_folios.Split('/')[0].Split('-')[1]);
            var folio_hasta = int.Parse(rango_folios.Split('/')[1]);

            var folio_documento = 1;
            for (var folio_legajo = folio_desde; folio_legajo <= folio_hasta; folio_legajo++)
            {
                this.folios.Add(new FolioModi(folio_legajo, folio_documento, una_tabla, un_id));
                folio_documento++;
            }
        }
    }
}
