using System;

namespace General.Repositorios
{
    public class CacheCargada<T>: Cache<T>
    {
        protected T ResultadoCacheado;

        public CacheCargada(T resultado)
        {
            this.ResultadoCacheado = resultado;
        }
        override public T Ejecutar(Func<T> FuncionConectarBase, RepositorioLazy<T> repo)
        {
            return this.ResultadoCacheado;
        }
    }
}
