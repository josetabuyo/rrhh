using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeTickets
    {
        IConexionBD conexion;

        public RepositorioDeTickets(IConexionBD una_conexion)
        {
            this.conexion = una_conexion;
        }
        public void DerivarTareas(int id_usuario_a_derivar, int[] tareas, int id_usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@id_usuario_a_derivar", id_usuario_a_derivar);
            parametros.Add("@id_usuario_derivador", id_usuario);

            tareas.ToList().ForEach(tarea => { 
                parametros.Add("@id_tarea", tarea);
                this.conexion.EjecutarSinResultado("dbo.MAU_UPD_TicketPorDerivacion", parametros);
                parametros.Remove("@id_tarea");
            });

        }

        public List<Ticket> GetTicketsPorFuncionalidad(int idUsuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idUsuario", idUsuario);
            var tabla_resultado = this.conexion.Ejecutar("dbo.MAU_GET_TicketsPorFuncionalidad", parametros);

            var tareas = new List<Ticket>();
            Area area = new Area();

            tabla_resultado.Rows.ForEach(row =>
            {
                Persona creador = new Persona(row.GetInt("IdPersona"), row.GetInt("NroDocumento"), row.GetString("nombre"), row.GetString("apellido"), area);
                Persona asignado = new Persona(row.GetInt("IdPersonaAsignada", 0), row.GetInt("NroDocumentoPersonaAsignada", 0), row.GetString("nombreAsignado", ""), row.GetString("apellidoAsignado", ""), area);
                var tipoTarea = new TipoTicket(row.GetInt("idTipoTicket", 0), row.GetString("codigo", ""), row.GetString("descripcionTipo", ""), row.GetString("url", ""), row.GetInt("idFuncionalidad", 0));
                Usuario usuarioCreador = new Usuario(row.GetSmallintAsInt("idUsuario", 0), row.GetString("nombreUsuario", ""), "", creador, true);
                Usuario usuarioAsignado = new Usuario(row.GetSmallintAsInt("idUsuarioAsignado", 0), row.GetString("nombreUsuarioAsignado", ""), "", asignado, true);
                Ticket ticket = new Ticket(row.GetInt("idTicket", 0), tipoTarea, row.GetDateTime("fechaCreacion"), usuarioCreador, usuarioAsignado, row.GetBoolean("estado"));

                tareas.Add(ticket);
            });
            return tareas;
        }


        public List<ResumenTipoTicket> GetResumenTicketsPorFuncionalidad(int idUsuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idUsuario", idUsuario);
            var tabla_resultado = this.conexion.Ejecutar("dbo.MAU_GET_ResumenTicketsPorFuncionalidad", parametros);

            var tareas = new List<ResumenTipoTicket>();

            tabla_resultado.Rows.ForEach(row =>
            {
                ResumenTipoTicket res_ticket = new ResumenTipoTicket(row.GetString("descripcionTipo", ""), row.GetInt("cantidad", 0));

                tareas.Add(res_ticket);
            });
            return tareas;
        }

        public int crearTicket(Ticket ticket, Usuario usuario)
        {
            return this.crearTicket(ticket.tipoTicket.codigo, usuario.Id);
        }

        public int crearTicket(string codigoTipo, int idUsuarioCreador)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@idUsuarioCreador", idUsuarioCreador);
                parametros.Add("@codigoTipo", codigoTipo);

                return Int32.Parse((this.conexion.EjecutarEscalar("dbo.MAU_INS_Ticket", parametros).ToString()));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void MarcarEstadoTicket(int id_ticket, int id_usuario)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@idTicket", id_ticket);
                this.conexion.EjecutarSinResultado("dbo.MAU_MarcarEstadoTicket", parametros);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}