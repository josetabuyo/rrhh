using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Modi
{
    public class LegajoModil
    {
        private List<DocumentoModil> _documentos = new List<DocumentoModil>();
        public int idInterna { get; set; }
        public int numeroDeDocumento { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        public LegajoModil()
        {

        }

        public LegajoModil(int un_id, int documento, string un_nombre, string un_apellido)
        {
            this.idInterna = un_id;
            this.numeroDeDocumento = documento;
            this.nombre = un_nombre;
            this.apellido = un_apellido;
        }

        public int cantidadDeDocumentos()
        {
            return _documentos.Count;
        }

        public List<DocumentoModil> documentos()
        {
            return _documentos;            
        }

        internal void agregarDocumentos(List<DocumentoModil> documentos)
        {
            this._documentos.AddRange(documentos);
        }
    }
}
