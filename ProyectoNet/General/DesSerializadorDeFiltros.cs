namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;

    public class DesSerializadorDeFiltros
    {
        private Mensajeria mensajeria;

        public DesSerializadorDeFiltros(Mensajeria _mensajeria)
        {
            this.mensajeria = _mensajeria;
        }

        public List<FiltroDeDocumentos> DesSerializarFiltros(List<String> filtrosSerializados)
        {
            var filtros = new List<FiltroDeDocumentos>();
            filtrosSerializados.ForEach(f => filtros.Add(this.DesSerializarFiltro(f)));
            return filtros;
        }

        public List<FiltroDeDocumentos> DesSerializarFiltros(string filtrosSerializados)
        {
            var filtrosDTO = JsonConvert.DeserializeObject<List<Dictionary<String, String>>>(filtrosSerializados);
            return DesSerializarFiltros(filtrosDTO);
        }

        private List<FiltroDeDocumentos> DesSerializarFiltros(List<Dictionary<string, string>> filtrosDTO)
        {
            var filtros = new List<FiltroDeDocumentos>();
            filtrosDTO.ForEach(f => filtros.Add(this.DesSerializarFiltro(f)));
            return filtros;
        }

        public FiltroDeDocumentos DesSerializarFiltro(String filtroSerializado)
        {
            var filtroDTO = JsonConvert.DeserializeObject<Dictionary<String, String>>(filtroSerializado);
            return DesSerializarFiltro(filtroDTO);
        }

        private FiltroDeDocumentos DesSerializarFiltro(Dictionary<string, string> filtroDTO)
        {
            var tipoFiltro = "General." + filtroDTO["tipoDeFiltro"];
            var assembly = typeof(FiltroDeDocumentos).Assembly;

            FiltroDeDocumentos filtro;
            if (filtroDTO["tipoDeFiltro"] == "FiltroDeDocumentosPorAreaActual" ||
                filtroDTO["tipoDeFiltro"] == "FiltroDeDocumentosPorTransicion" ||
                filtroDTO["tipoDeFiltro"] == "FiltroDeDocumentosPorTiempoEnUltimaAreaMayorOIgualA"
                )
                filtro = (FiltroDeDocumentos)Activator.CreateInstance(assembly.GetType(tipoFiltro), new Object[] { filtroDTO, mensajeria });
            else
                filtro = (FiltroDeDocumentos)Activator.CreateInstance(assembly.GetType(tipoFiltro), new Object[] { filtroDTO });

            return filtro;
        }




    }
}