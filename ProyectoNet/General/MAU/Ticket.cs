using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class Ticket
    {
        //public int Id { get; set; }
        //public TipoAlertaPortal Tipo { get; set; }

        public string descripcion { get; set; }
        public string titulo { get; set; }
        public int id { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Usuario usuarioCreador { get; set; }
        public Usuario usuarioAsignado { get; set; }
        public TipoTicket tipoTicket { get; set; }
        public string estado { get; set; }

        public Ticket()
        { }

        public Ticket(int id, string titulo, string descripcion, TipoTicket tipoTicket, DateTime fechaCreacion, Usuario usuarioCreador, Usuario usuarioAsignado, string estado)
        {
            this.descripcion = descripcion;
            this.titulo = titulo;
            this.id = id;
            this.tipoTicket = tipoTicket;
            this.fechaCreacion = fechaCreacion;
            this.usuarioCreador = usuarioCreador;
            this.usuarioAsignado = usuarioAsignado;
            this.estado = estado;
        }

        public Ticket(int id, TipoTicket tipoTicket, DateTime fechaCreacion, Usuario usuarioCreador, Usuario usuarioAsignado, bool estado)
        {
            this.id = id;
            this.tipoTicket = tipoTicket;
            this.fechaCreacion = fechaCreacion;
            this.usuarioCreador = usuarioCreador;
            this.estado = estado.ToString();
        }
    }
}
