using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class PantallaRecepcionDocumentacion
    {

        public List<DivDocumentacionRequerida> DocumentacionRequerida { get; set; }
        public List<DivDocumentacionRequerida> CuadroPerfil { get; protected set; }
        public List<DocumentacionRecibida> DocumentacionRecibida { get; set; }
        public List<string> RequisitosPerfil { get; set; }
        public Postulacion Postulacion { get; set; }


        public PantallaRecepcionDocumentacion()
        {
            this.CuadroPerfil = new List<DivDocumentacionRequerida>();
            this.DocumentacionRecibida = new List<DocumentacionRecibida>();
            this.RequisitosPerfil = new List<string>();
        }

        public int IdPostulacion { get { return Postulacion.Id; } set { } }

    }
}
