using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Modi
{
    public class FolioModi
    {
        public int numero_folio { get; set; }
        public ImagenModi imagen { get; set; }

        public FolioModi()
        {

        }
        public FolioModi(int nro_folio)
        {
            this.numero_folio = nro_folio;
        }
    }
}
