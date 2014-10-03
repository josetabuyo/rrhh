using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class PatallaRecepcionDocumentacion
    {

        public List<DivDocumentacionRequerida> DocumentacionRequerida { get; set; }
        public List<DivDocumentacionRequerida> CuadroPerfil { get; protected set; }


        public PatallaRecepcionDocumentacion()
        {
            this.CuadroPerfil = new List<DivDocumentacionRequerida>();
        }

    }
}
