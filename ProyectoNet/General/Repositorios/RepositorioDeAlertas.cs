using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.Repositorios
{
    public class RepositorioDeAlertas
    {
        private Mensajeria _mensajeria;
        public RepositorioDeAlertas(Mensajeria mensajeria)
        {
            _mensajeria = mensajeria;
        }
        public List<List<FiltroDeDocumentos>> GetAlertas()
        {
            var listaAlertas = new List<List<FiltroDeDocumentos>>();

            List<FiltroDeDocumentos> alerta = new List<FiltroDeDocumentos>();

            alerta.Add(new FiltroDeDocumentosPorTipoDocumento(1));
            alerta.Add(new FiltroDeDocumentosPorAreaActual(this._mensajeria,1));

            listaAlertas.Add(alerta);
            return listaAlertas;
        }
    }
}
