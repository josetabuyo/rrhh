using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class Destinatario
    {
        public int id_notificacion;
        public Persona persona;
        public DateTime fechaLectura;
        public bool leido;

        public Destinatario() { }

        public Destinatario(int id_notificacion, Persona persona, DateTime fechaLectura, bool leido)
        {
            this.id_notificacion = id_notificacion;
            this.persona = persona;
            this.fechaLectura = fechaLectura;
            this.leido = leido;
        }


    }

}
