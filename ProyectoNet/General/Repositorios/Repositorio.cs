using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class Repositorio<T>
    {
        protected IConexionBD conexion;
        public Repositorio(IConexionBD conexion)
        {
            this.conexion = conexion;
        }

    }
}
