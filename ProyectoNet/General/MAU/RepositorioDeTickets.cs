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
       
        public List<Ticket> GetTicketsPorFuncionalidad(int idUsuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idUsuario", idUsuario);
            var tabla_resultado = this.conexion.Ejecutar("dbo.MAU_GET_TicketsPorFuncionalidad", parametros);

            var tareas = new List<Ticket>();
            Area area = new Area();

            tabla_resultado.Rows.ForEach(row =>
            {
                Persona creador = new Persona(row.GetInt("Id"), row.GetInt("NroDocumento"), row.GetString("nombre"), row.GetString("apellido"), area);
                var tipoTarea = new TipoTicket(row.GetInt("idtipo", 0), row.GetString("descripcionTipo", ""), row.GetString("url", ""), row.GetInt("idFuncionalidad", 0));
                Usuario usuarioCreador = new Usuario(row.GetSmallintAsInt("idUsuario", 0), row.GetString("nombreUsuario", ""), "", creador, true);
                Ticket ticket = new Ticket(row.GetInt("id", 0), tipoTarea, row.GetDateTime("fechaCreacion"), usuarioCreador, row.GetBoolean("estado"));

                tareas.Add(ticket);
            });
            return tareas;
        }

        public int crearTicket(Ticket ticket, Usuario usuario)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@idUsuarioCreador", usuario.Id);
                parametros.Add("@idTipo", ticket.tipoTicket.id);

                return Int32.Parse((this.conexion.EjecutarEscalar("dbo.MAU_INS_Tarea", parametros).ToString()));
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