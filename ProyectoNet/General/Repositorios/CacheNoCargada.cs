using System;
using General.Repositorios;

namespace General.Repositorios
{
    public class CacheNoCargada<T>: Cache<T>
    {

        override public T Ejecutar(Func<T> FuncionConectarBase, RepositorioLazy<T> repo) 
        {
            var resultado = FuncionConectarBase.Invoke();
            repo.RealizasteConexion(resultado);
            return resultado;
        }
    }
}
