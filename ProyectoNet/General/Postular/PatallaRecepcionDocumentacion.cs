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
        public List<DocumentacionRecibida> DocumentacionRecibida { get; set; }
        public Postulacion Postulacion { get; set; }


        public PatallaRecepcionDocumentacion()
        {
            this.CuadroPerfil = new List<DivDocumentacionRequerida>();
        }

        public int IdPostulacion { get { return Postulacion.Id; } set { } }
    }
}
