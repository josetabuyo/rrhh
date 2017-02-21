using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class Notificacion
    {
        public int Id;
        public Persona creador;
        public DateTime fechaCreacion;
        public string texto;
        public List<Destinatario> destinatarios;
        public bool leido;

        public Notificacion() { }

        public Notificacion(int id, Persona creador, DateTime fechaCreacion, string texto, List<Destinatario> destinatarios)
        {
            this.Id = id;
            this.creador = creador;
            this.fechaCreacion = fechaCreacion;
            this.texto = texto;
            this.destinatarios = destinatarios;
        }
        public Notificacion(int id, Persona creador, DateTime fechaCreacion, string texto, List<Destinatario> destinatarios, bool leido)
        {
            this.Id = id;
            this.creador = creador;
            this.fechaCreacion = fechaCreacion;
            this.texto = texto;
            this.leido = leido;
        }
    }
}
