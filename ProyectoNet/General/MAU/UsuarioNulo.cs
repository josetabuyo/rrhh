using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;

namespace General.MAU
{
    public class UsuarioNulo:Usuario
    {
        public UsuarioNulo()
        {

        }

        public override bool ValidarClave(string clave)
        {
            return false;
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
