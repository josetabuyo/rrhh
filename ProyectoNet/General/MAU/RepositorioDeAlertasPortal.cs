using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeAlertasPortal
    {
        IConexionBD conexion;

        public RepositorioDeAlertasPortal(IConexionBD una_conexion)
        {
            this.conexion = una_conexion; 
        }

        public List<AlertaPortal> GetAlertasPendientesPara(int id_usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario_destinatario", id_usuario);
            var tabla_resultado = this.conexion.Ejecutar("dbo.MAU_GetAlertasPendientes", parametros);

            var alertas = new List<AlertaPortal>();

            tabla_resultado.Rows.ForEach(row =>
            {
                var alerta = new AlertaPortal();
                alerta.Id = row.GetInt("id");
                alerta.Tipo = new TipoAlertaPortal();
                alerta.Tipo.Id = row.GetInt("idtipo");
                alerta.Tipo.Nombre = row.GetString("tipo");
                alerta.Titulo = row.GetString("titulo");
                alerta.Descripcion = row.GetString("descripcion");

                alertas.Add(alerta);
            });
            return alertas;
        }

        public void MarcarAlertaComoLeida(int id_alerta, int id_usuario)
        {
            var alertas = GetAlertasPendientesPara(id_usuario);
            if (!alertas.Any(a => a.Id == id_alerta)) throw new Exception("no puede marcar como leidas las alertas que no son para usted");
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_alerta", id_alerta);
            this.conexion.EjecutarSinResultado("dbo.MAU_MarcarAlertaComoLeida", parametros);
        }
    }
}
