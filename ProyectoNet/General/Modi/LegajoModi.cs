using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Modi
{
    public class LegajoModi
    {
        public List<DocumentoModi> documentos = new List<DocumentoModi>();
        public int idInterna { get; set; }
        public int numeroDeDocumento { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        public LegajoModi()
        {

        }

        public LegajoModi(int un_id, int documento, string un_nombre, string un_apellido)
        {
            this.idInterna = un_id;
            this.numeroDeDocumento = documento;
            this.nombre = un_nombre;
            this.apellido = un_apellido;
        }

        public int cantidadDeDocumentos()
        {
            return documentos.Count;
        }

        internal void agregarDocumentos(List<DocumentoModi> documentos)
        {
            this.documentos.AddRange(documentos);
        }
    }
}
