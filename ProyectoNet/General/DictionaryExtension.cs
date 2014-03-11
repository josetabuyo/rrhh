using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;

namespace General
{
    public static class DictionaryExtension
    {

        public static List<Area> GetValueOrDefault(this Dictionary<Usuario, List<Area>> areas, Usuario key, List<Area> valor_defecto)
        {
            try
            {
                return areas[key];
            }
            catch (KeyNotFoundException)
            {
                return valor_defecto;
            }
        }
        public static List<Funcionalidad> GetValueOrDefault(this Dictionary<Usuario, List<Funcionalidad>> areas, Usuario key, List<Funcionalidad> valor_defecto)
        {
            try
            {
                return areas[key];
            }
            catch (KeyNotFoundException)
            {
                return valor_defecto;
            }
        }
    }
}
