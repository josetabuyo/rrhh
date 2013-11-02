using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionesDeLista
{
    public static class ExtensionList
    {

        public static T Find<T>(this List<T> list, Predicate<T> match, Func<T> si_no_hay_nada)
        {
            var resultado = list.Find(match);
            if (resultado == null)
                return si_no_hay_nada.Invoke();
            return resultado;
        }

        public static T Find<T>(this List<T> list, Predicate<T> match, T si_no_hay_nada)
        {
            var resultado = list.Find(match);
            if (resultado == null)
                return si_no_hay_nada;
            return resultado;
        }

        public static List<T> FindAll<T>(this List<T> list, Predicate<T> match, T si_no_hay_nada)
        {
            var resultado = list.FindAll(match);
            if (resultado.Count <= 0)
                return new List<T> () { si_no_hay_nada };
            return resultado;
        }
    }
}
