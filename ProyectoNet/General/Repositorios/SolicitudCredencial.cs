using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class SolicitudCredencial
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public int IdTipoCredencial { get; set; }
        public string Motivo { get; set; }
        public string Organismo { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public int IdTicketAprobacion { get; set; }
        public int IdTicketImpresion { get; set; }
        public Credencial Credencial { get; set; }
       
        public SolicitudCredencial()
        {
                
        }

        public SolicitudCredencial(int id, int idpersona, int tipo, string motivo, string organismo, string estado, int ticket_aprobacion, int ticket_impresion, DateTime fecha)
        {
            this.Id = id;
            this.IdPersona = idpersona;
            this.IdTipoCredencial = tipo;
            this.Motivo = motivo;
            this.Organismo = organismo;
            this.Estado = estado;
            this.IdTicketAprobacion = ticket_aprobacion;
            this.IdTicketImpresion = ticket_impresion;
            this.Fecha = fecha;
        }




    }
}
