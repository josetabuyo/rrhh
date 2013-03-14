using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace General
{
    public class Validador
    {
        public void NoEsNulo(object algo, string descripcion)
        {
            if (algo == null)
                throw new ExcepcionDeValidacion(descripcion + ", no puede ser null");
        }

        public void EsValidoComoId(int id, string descripcion)
        {
            if (id == 0)
                throw new ExcepcionDeValidacion(descripcion + " 0 no es valido como id");
        }

        public void EstaEnLaColeccion(IList una_coleccion, object item, string descripcion)
        {
            if (!una_coleccion.Contains(item))
                throw new ExcepcionDeValidacion(item.ToString() + ", no pertenece a la coleccion de " + descripcion);
           
        }
    }
}
