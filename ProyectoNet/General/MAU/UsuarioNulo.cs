using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;

namespace General.MAU
{
    public class UsuarioNulo:Usuario
    {
        public bool EsNulo { get; set; }
        public UsuarioNulo()
        {
            this.EsNulo = true;
            this.Owner = null;
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
