using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
   public class Documento_DTO_Alta
    {
       /*
            extracto: cfg.txtExtracto.val(),
            tipo: cfg.idTipoDeDocumentoSeleccionadoEnAlta.val(),
            categoria: cfg.cmbCategoriaDocumento.val(),
            id_area_origen: cfg.areaOrigenSeleccionadaEnAlta.val(),
            id_area_destino: cfg.areaDestinoSeleccionadaEnAlta.val(),
            id_area_actual: cfg.areaDelUsuario.id,
            numero: cfg.txtNumero.val(),
            comentarios: cfg.txtComentarios.val()*/

        private string _extracto;
        private int _tipo;
        private int _categoria;
        private int _id_area_origen;
        private int _id_area_destino;
        private int _id_area_actual; 
        private string _numero; 
        private string _comentarios;
       
        public string extracto { get { return _extracto; } set { _extracto = value; } }
        public int tipo { get { return _tipo; } set { _tipo = value; } }
        public int categoria { get { return _categoria; } set { _categoria = value; } }
        public int id_area_origen { get { return _id_area_origen; } set { _id_area_origen = value; } }
        public int id_area_destino { get { return _id_area_destino; } set { _id_area_destino = value; } }
        public int id_area_actual { get { return _id_area_actual; } set { _id_area_actual = value; } }
        public string numero { get { return _numero; } set { _numero = value; } }
        public string comentarios { get { return _comentarios; } set { _comentarios = value; } }
     
        public Documento_DTO_Alta()
        {
        }


    

        public Documento toDocumento()
        {
            TipoDeDocumentoSICOI tipoDocumento = new TipoDeDocumentoSICOI(this._tipo,"");
            var numero = this._numero;
            CategoriaDeDocumentoSICOI categoria_documento = new CategoriaDeDocumentoSICOI(this._categoria,"");
            Area area_origen = new Area(this._id_area_origen);
            Area area_destino = new Area(this._id_area_destino);
            Area area_actual = new Area(this._id_area_actual);
            string extracto_documento = this._extracto;
            string comentarios = this._comentarios;

            Documento documento = new Documento(tipoDocumento, numero, categoria_documento, area_origen, extracto_documento, area_destino, comentarios);

            return documento;
        }

    }
}
