using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Modi
{
    public class DocumentoModi
    {
        private List<ThumbnailImagenModi> imagenesAsignadas;
        public string descripcionEnRRHH { get; set; }
        public string jurisdiccion { get; set; }
        public string organismo { get; set; }
        public string folio { get; set; }
        public DateTime fechaDesde { get; set; }
        public string tabla { get; set; }
        public int id { get; set; }

        public DocumentoModi()
        {
            this.imagenesAsignadas = new List<ThumbnailImagenModi>();
        }
        public DocumentoModi(  string una_tabla,
                                int un_id,
                                string unaDescripcion, 
                                string una_jurisdiccion, 
                                string un_organismo, 
                                string un_folio, 
                                DateTime una_fecha_desde )
        {
            this.descripcionEnRRHH = unaDescripcion;
            this.jurisdiccion = una_jurisdiccion;
            this.organismo = un_organismo;
            this.folio = un_folio;
            this.fechaDesde = una_fecha_desde;
            this.tabla = una_tabla;
            this.id = un_id;
            this.imagenesAsignadas = new List<ThumbnailImagenModi>();
        }

        public List<ThumbnailImagenModi> thumbnailsImagenesAsignadas
        {
            get
            {
                return imagenesAsignadas;
            }
        }

        public bool tieneImagenes()
        {
            return imagenesAsignadas.Any();
        }

    }
}
