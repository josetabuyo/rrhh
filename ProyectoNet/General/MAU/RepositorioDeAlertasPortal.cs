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
                Usuario usuarioCreador = new Usuario(row.GetSmallintAsInt("idUsuario", 0), row.GetString("nombreUsuario", ""), "", true);
                AlertaPortal alerta = new AlertaPortal(row.GetInt("id", 0), row.GetString("titulo", ""), row.GetString("descripcion", ""), row.GetDateTime("fechaCreacion"), usuarioCreador, "Un Estado");

                alertas.Add(alerta);
            });
            return alertas;
        }

        public void MarcarAlertaComoLeida(int id_alerta, int id_usuario)
        {
            var alertas = GetAlertasPendientesPara(id_usuario);
            if (!alertas.Any(a => a.id == id_alerta)) throw new Exception("no puede marcar como leidas las alertas que no son para usted");
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_alerta", id_alerta);
            this.conexion.EjecutarSinResultado("dbo.MAU_MarcarAlertaComoLeida", parametros);
        }

        public int crearAlerta(string titulo, string descripcion, int id_usuario_destinatario, int id_usuario_creador)
        {   
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario_destinatario", id_usuario_destinatario);
            parametros.Add("@id_usuario_creador", id_usuario_creador);
            parametros.Add("@titulo", titulo);
            parametros.Add("@descripcion", descripcion);

            return Int32.Parse((this.conexion.EjecutarEscalar("dbo.MAU_CrearAlerta", parametros).ToString()));

        }

        public int crearAlerta(AlertaPortal alerta, int idUsuarioDestinatario, Usuario usuario)
        {
            return this.crearAlerta(alerta.titulo, alerta.descripcion, idUsuarioDestinatario, usuario.Id);
        }
    }
}