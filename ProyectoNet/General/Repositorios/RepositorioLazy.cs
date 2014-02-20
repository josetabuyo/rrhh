using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioLazy<T>:Repositorio<T>
    {
        public RepositorioLazy(IConexionBD conexion)
            :base(conexion)
        {
            this.cache = new CacheNoCargada<T>();
        }
        protected Cache<T> cache;
        public void RealizasteConexion(T resultado)
        {
            this.cache = new CacheCargada<T>(resultado);
        }
    }
}
