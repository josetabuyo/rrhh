using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Modi
{
    public class FolioModi
    {
        public int folioLegajo { get; set; }
        public int folioDocumento { get; set; }
        public string tabla { get; set; }
        public int idDocumento { get; set; }
        public List<ImagenModi> imagenes { get; set; }

        public FolioModi()
        {
            this.imagenes = new List<ImagenModi>();
        }
        public FolioModi(int folio_leg, int folio_doc, string tabla, int id_doc)
        {
            this.imagenes = new List<ImagenModi>();
            this.folioLegajo = folio_leg;
            this.folioDocumento = folio_doc;
            this.tabla = tabla;
            this.idDocumento = id_doc;
        }
    }
}
