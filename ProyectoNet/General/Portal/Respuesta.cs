using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class Respuesta
    {
        public int id_orden;
        public Persona persona;
        public DateTime fecha;
        public string texto;

        public Respuesta() { }

        public Respuesta(int id_orden, Persona persona, DateTime fecha, string texto) {
            this.id_orden = id_orden;
            this.persona = persona;
            this.fecha = fecha;
            this.texto = texto;
        }


    }

}
