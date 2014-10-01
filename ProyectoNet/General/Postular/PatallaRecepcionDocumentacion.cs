using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class PatallaRecepcionDocumentacion
    {

        public List<DocumentacionRequerida> DocumentacionRequerida { get; set; }
        public List<DocumentacionRequerida> CuadroPerfil { get; protected set; }


        public PatallaRecepcionDocumentacion()
        {
            this.CuadroPerfil = new List<DocumentacionRequerida>();
        }

    }
}
