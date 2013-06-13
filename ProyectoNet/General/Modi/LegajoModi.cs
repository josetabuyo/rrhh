using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Modi
{
    public class LegajoModi
    {
        public List<DocumentoModi> documentos = new List<DocumentoModi>();
        public List<ImagenModi> imagenesSinAsignar = new List<ImagenModi>();
        
        public int idInterna { get; protected set; }
        public int numeroDeDocumento { get; protected set; }
        public string nombre { get; protected set; }
        public string apellido { get; protected set; }
        public string codigoDeResultado { get; protected set; }

        public LegajoModi()
        {
            this.codigoDeResultado = "LEGAJO_NO_ENCONTRADO";
        }

        public LegajoModi(int un_id, int documento, string un_nombre, string un_apellido)
        {
            this.idInterna = un_id;
            this.numeroDeDocumento = documento;
            this.nombre = un_nombre;
            this.apellido = un_apellido;
            this.codigoDeResultado = "OK";
        }

        public int cantidadDeDocumentos()
        {
            return documentos.Count;
        }

        public void agregarDocumentos(List<DocumentoModi> documentos)
        {
            this.documentos.AddRange(documentos);
        }

        public void agregarImagenesSinAsignar(List<ImagenModi> imagenes)
        {
            this.imagenesSinAsignar.AddRange(imagenes);
        }

    }
}
