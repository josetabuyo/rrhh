using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
   public class Documento_DTO_Alta
    {
        public string extracto { get; set; }
        public string tipo { get; set; }
        public string categoria { get; set; }
        public string id_area_origen { get; set; }
        public string id_area_destino { get; set; }
        public string id_area_actual { get; set; }
        public string numero { get; set; }
        public string comentarios { get; set; }

        public Documento_DTO_Alta()
        {
        }           

        public Documento toDocumento()
        {
            TipoDeDocumentoSICOI tipoDocumento = new TipoDeDocumentoSICOI(int.Parse(this.tipo),"");
            var numero = this.numero;
            CategoriaDeDocumentoSICOI categoria_documento = new CategoriaDeDocumentoSICOI(int.Parse(this.categoria),"");
            Area area_origen = new Area(int.Parse(this.id_area_origen));
            string extracto_documento = this.extracto;
            string comentarios = this.comentarios;

            Documento documento = new Documento(tipoDocumento, numero, categoria_documento, area_origen, extracto_documento, comentarios);

            return documento;
        }
    }
}
