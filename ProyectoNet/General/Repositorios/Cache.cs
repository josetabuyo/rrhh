using System;

namespace General.Repositorios
{
    public abstract class Cache<T>
    {
        public abstract T Ejecutar(Func<T> FuncionConectarBase, RepositorioLazy<T> repo);
    }
}
