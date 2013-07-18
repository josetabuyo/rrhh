using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioLazy<T>
    {
        protected Cache<T> accion_de_conexion;
        public void RealizasteConexion(T resultado)
        {
            this.accion_de_conexion = new CacheCargada<T>(resultado);
        }
    }
}
