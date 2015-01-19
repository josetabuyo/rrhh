using System;
using Dominio;
using System.Collections.Generic;

namespace General.Repositorios
{
    public class RepositorioDeTickets
    {
        public IConexionBD conexion_bd { get; set; }

        public RepositorioDeTickets(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        private string codigo_inicial;
        private Etiquetador etiquetador;

        public string GenerarTicket(string modulo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@modulo", modulo);
            codigo_inicial = conexion_bd.EjecutarEscalar("dbo.VIA_GetUltimoCodigoDeTicket", parametros).ToString();

            etiquetador = new Etiquetador(codigo_inicial);
            parametros.Add("@codigoTicket", etiquetador.Siguiente());
            var resultado = conexion_bd.EjecutarSinResultado("dbo.VIA_GuardarTicket", parametros);

            if (resultado) return etiquetador.Actual();
            return string.Empty;
        }
    }
}
