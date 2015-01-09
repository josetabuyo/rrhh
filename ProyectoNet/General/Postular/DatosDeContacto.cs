using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class DatosDeContacto
    {
        protected string _telefono;
        protected string _telefono2;
        protected string _email;

        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Telefono2 { get { return _telefono2; } set { _telefono2 = value; } }
        public string Email { get { return _email; } set { _email = value; } }

    public DatosDeContacto()
        {
        }

    public DatosDeContacto(string telefono, string telefono2, string email)
    {
       _telefono = telefono;
       _telefono2 = telefono2;
       _email = email;  
    }

    }   
}
