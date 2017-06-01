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
                TipoAlertaPortal tipoTarea = new TipoAlertaPortal(row.GetInt("idtipo", 0), row.GetString("descripcionTipo", ""), row.GetString("url", ""), row.GetInt("idFuncionalidad", 0));
                Usuario usuarioCreador = new Usuario(row.GetSmallintAsInt("idUsuario", 0), row.GetString("nombreUsuario", ""), "", true);
                AlertaPortal alerta = new AlertaPortal(row.GetInt("id", 0), row.GetString("titulo", ""), row.GetString("descripcion", ""), tipoTarea, row.GetDateTime("fechaCreacion"), usuarioCreador, "Un Estado");
               /* var alerta = new AlertaPortal();
                alerta.Id = row.GetInt("id");
                alerta.Tipo = new TipoAlertaPortal();
                alerta.Tipo.Id = row.GetInt("idtipo");
                alerta.Tipo.Nombre = row.GetString("tipo");
                alerta.Titulo = row.GetString("titulo");
                alerta.Descripcion = row.GetString("descripcion");*/

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

        public List<AlertaPortal> getAlertasPorFuncionalidad(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idUsuario", usuario.Id);
            var tabla_resultado = this.conexion.Ejecutar("dbo.MAU_GetAlertasPorFuncionalidad", parametros);

            List<AlertaPortal> alertas = new List<AlertaPortal>();
            Area area = new Area();
            tabla_resultado.Rows.ForEach(row =>
            {
                Persona creador = new Persona(row.GetInt("Id"), row.GetInt("NroDocumento"), row.GetString("nombre"), row.GetString("apellido"), area);
                TipoAlertaPortal tipoTarea = new TipoAlertaPortal(row.GetInt("idtipo", 0), row.GetString("descripcionTipo", ""), row.GetString("url", ""), row.GetInt("idFuncionalidad", 0));
                Usuario usuarioCreador = new Usuario(row.GetSmallintAsInt("idUsuario", 0), row.GetString("nombreUsuario", ""), "",creador, true);
                AlertaPortal alerta = new AlertaPortal(row.GetInt("id", 0), row.GetString("titulo", ""), row.GetString("descripcion", ""), tipoTarea, row.GetDateTime("fechaCreacion"), usuarioCreador, "Un Estado");


                alertas.Add(alerta);
            });

            return alertas;
        }

        public int crearAlerta(AlertaPortal alerta, int idUsuarioDestinatario, Usuario usuario)
        {
            //try
           // {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@id_usuario_destinatario", idUsuarioDestinatario);
                parametros.Add("@id_usuario_creador", usuario.Id);
                parametros.Add("@id_tipo", alerta.tipoAlerta.id);
                parametros.Add("@titulo", alerta.titulo);
                parametros.Add("@descripcion", alerta.descripcion);

                return Int32.Parse((this.conexion.EjecutarEscalar("dbo.MAU_CrearAlerta", parametros).ToString()));
          //  }
          //  catch (Exception e) {
           //     throw new Exception(e.Message);
          //  }
            
        }

        public void MAU_MarcarEstadoAlerta(int id_alerta, int id_usuario)
        {
           // try
          //  {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@id_alerta", id_alerta);
                this.conexion.EjecutarSinResultado("dbo.MAU_MarcarEstadoAlerta", parametros);
          //  }
          //  catch (Exception e)
          //  {
           //     throw new Exception(e.Message);
          //  }
        }

       
    }
}
