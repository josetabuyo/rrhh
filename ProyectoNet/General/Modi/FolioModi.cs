using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Modi
{
    public class FolioModi
    {
        public int numero_folio { get; set; }
        public List<ImagenModi> imagenes { get; set; }

        public FolioModi()
        {
            this.imagenes = new List<ImagenModi>();
        }
        public FolioModi(int nro_folio)
        {
            this.imagenes = new List<ImagenModi>();
            this.numero_folio = nro_folio;
        }
    }
}
