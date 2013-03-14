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

        public string GenerarTicket()
        {

            var parametros = new Dictionary<string, object>();
            //ConexionDB cn = new ConexionDB("VIA_GetUltimoCodigoDeTicket");
            codigo_inicial = conexion_bd.EjecutarEscalar("dbo.VIA_GetUltimoCodigoDeTicket").ToString(); //cn.EjecutarEscalar().ToString();
            etiquetador = new Etiquetador(codigo_inicial);

            //cn = new ConexionDB("VIA_GuardarTicket");
            //cn.AsignarParametro("@codigoTicket", etiquetador.Siguiente());
            parametros.Add("@codigoTicket", etiquetador.Siguiente());

            var resultado = conexion_bd.EjecutarSinResultado("dbo.VIA_GuardarTicket", parametros);// cn.EjecutarSinResultado();
            if (resultado) 
                return etiquetador.Actual();
            return string.Empty;
        }
    }
}
