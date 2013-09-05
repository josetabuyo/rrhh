using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Responsable
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Mail { get; set; }


        public Responsable(string nombre, string apellido, string telefono, string fax, string mail)
        {
            // TODO: Complete member initialization
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Fax = fax;
            this.Mail = mail;
        }

        public Responsable()
        {
            // TODO: Complete member initialization
        }

    }

}
