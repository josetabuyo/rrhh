using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
   public class Documento_DTO_Alta
    {
        private int _id;
        private TipoDeDocumentoSICOI _tipoDeDocumento;
        private string _numero;
        private CategoriaDeDocumentoSICOI _categoriaDeDocumento;
        private string _extracto;
        private string _comentarios;
        private string _ticket;
        private DateTime _fecha;

        public int Id { get { return _id; } set { _id = value; } }
        public TipoDeDocumentoSICOI tipoDeDocumento { get { return _tipoDeDocumento; } set { _tipoDeDocumento = value; } }
        public string numero { get { return _numero; } set { _numero = value; } }
        public CategoriaDeDocumentoSICOI categoriaDeDocumento { get { return _categoriaDeDocumento; } set { _categoriaDeDocumento = value; } }
        public string extracto { get { return _extracto; } set { _extracto = value; } }
        public string comentarios { get { return _comentarios; } set { _comentarios = value; } }
        public string ticket { get { return _ticket; } set { _ticket = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }


        public Documento_DTO_Alta()
        {


        }


    }
}
