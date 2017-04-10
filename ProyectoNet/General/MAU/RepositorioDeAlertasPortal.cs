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

        public List<AlertaPortal> GetAlertasPara(int id_usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario_destinatario", id_usuario);
            var tabla_resultado = this.conexion.Ejecutar("dbo.MAU_GetAlertas", parametros);

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
    }
}
