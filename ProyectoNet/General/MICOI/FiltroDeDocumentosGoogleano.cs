  using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

namespace General
{
    public class FiltroDeDocumentosGoogleano : FiltroDeDocumentos
    {
        private string Criterio;
        private Mensajeria mensajeria;

        public FiltroDeDocumentosGoogleano(Dictionary<String, String> filtroDto, Mensajeria _mensajeria)
        {
            Criterio = filtroDto["criterio"];
            mensajeria = _mensajeria;
        }

        public FiltroDeDocumentosGoogleano(string criterio)
        {
            Criterio = criterio;
        }

        public override bool aplicaPara(Documento documento)
        {
            var palabras_busqueda = Criterio.Split(' ').Select(p => p.ToUpper().Trim());
            var area_actual = mensajeria.EstaEnElArea(documento);
            var area_creadora = mensajeria.SeOriginoEnArea(documento);
            var area_destino = mensajeria.AreaDestinoPara(documento);
            return palabras_busqueda.All(p => documento.extracto.ToUpper().Trim().Contains(p) || 
                                                documento.numero.ToUpper().Contains(p) ||
                                                documento.comentarios.ToUpper().Contains(p) || 
                                                documento.ticket.ToUpper().Contains(p) || 
                                                documento.tipoDeDocumento.descripcion.ToUpper().Contains(p) || 
                                                documento.categoriaDeDocumento.descripcion.ToUpper().Contains(p) ||
                                                area_actual.NombreConAlias().ToUpper().Contains(p)||
                                                area_creadora.NombreConAlias().ToUpper().Contains(p)||
                                                area_destino.NombreConAlias().ToUpper().Contains(p));
        }      
    }
}
