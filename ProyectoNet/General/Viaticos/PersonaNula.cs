using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class PersonaNula:Persona
    {
        public PersonaNula()
        {
            this.Id = -1;
            this.Documento = -1;
            this.Nombre = "";
            this.Apellido = "";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return true;
        } 
    }
}
