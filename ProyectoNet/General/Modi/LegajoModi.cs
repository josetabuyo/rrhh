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
        
        public int idInterna { get; set; }
        public int numeroDeDocumento { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cuil { get; set; }
    
        public LegajoModi()
        {
        }

        public LegajoModi(int un_id, int documento, string un_nombre, string un_apellido, string un_cuil)
        {
            this.idInterna = un_id;
            this.numeroDeDocumento = documento;
            this.nombre = un_nombre;
            this.apellido = un_apellido;
            this.cuil = un_cuil;
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

        public FolioModi GetFolio(int nro_folio)
        {
            return this.documentos.SelectMany(d => d.folios).First(f => f.numero_folio == nro_folio);
        }
    }
}
