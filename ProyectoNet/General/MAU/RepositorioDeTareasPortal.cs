using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeTareasPortal
    {
        IConexionBD conexion;

        public RepositorioDeTareasPortal(IConexionBD una_conexion)
        {
            this.conexion = una_conexion;
        }
       
        public List<TareaPortal> GetTareasPorFuncionalidad(int idUsuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idUsuario", idUsuario);
            var tabla_resultado = this.conexion.Ejecutar("dbo.MAU_GET_TareasPorFuncionalidad", parametros);

            var tareas = new List<TareaPortal>();
            Area area = new Area();

            tabla_resultado.Rows.ForEach(row =>
            {
                Persona creador = new Persona(row.GetInt("Id"), row.GetInt("NroDocumento"), row.GetString("nombre"), row.GetString("apellido"), area);
                var tipoTarea = new TipoTareaPortal(row.GetInt("idtipo", 0), row.GetString("descripcionTipo", ""), row.GetString("url", ""), row.GetInt("idFuncionalidad", 0));
                Usuario usuarioCreador = new Usuario(row.GetSmallintAsInt("idUsuario", 0), row.GetString("nombreUsuario", ""), "", creador, true);
                TareaPortal tarea = new TareaPortal(row.GetInt("id", 0), tipoTarea, row.GetDateTime("fechaCreacion"), usuarioCreador, row.GetBoolean("estado"));

                tareas.Add(tarea);
            });
            return tareas;
        }

        public int crearTarea(TareaPortal alerta, Usuario usuario)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@idUsuarioCreador", usuario.Id);
                parametros.Add("@idTipo", alerta.tipoTarea.id);

                return Int32.Parse((this.conexion.EjecutarEscalar("dbo.MAU_INS_Tarea", parametros).ToString()));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void MarcarEstadoTarea(int id_tarea, int id_usuario)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@idTarea", id_tarea);
                this.conexion.EjecutarSinResultado("dbo.MAU_MarcarEstadoTarea", parametros);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}