using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;

namespace AdministracionDeUsuarios
{
    public class UsuarioNulo:Usuario
    {
        public override bool ValidarClave(string clave)
        {
            return false;
        }
    }
}
