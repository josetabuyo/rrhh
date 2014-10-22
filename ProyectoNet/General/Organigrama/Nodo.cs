using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Nodo
    {
        private Area area;
        private Nodo nodo_padre;

        public Nodo(Area area)
        {
            this.area = area;
            
        }

        public Area Area()
        {
            return area;
        }


        public void DependesDe(Nodo nodo)
        {
            this.nodo_padre = nodo;
        }

        virtual public bool EsRoot()
        {
            return false;
        }

        internal Area AreaPadre()
        {
            return nodo_padre.Area();
        }

        virtual internal List<Area> AreasSuperiores()
        {
            List<Area> areas_superiores = new List<Area>();
            areas_superiores.Add(nodo_padre.Area());
            areas_superiores.AddRange(nodo_padre.AreasSuperiores());
            return areas_superiores;

        }

        virtual internal List<Area> AreasInferioresInmediatasDe(Area un_area)
        {
            List<Area> areas_inferiores_inmediatas = new List<Area>();

            if (nodo_padre == null)
            {
                var a = 1;
            }
            if (nodo_padre.Area().Equals(un_area)){
            
                areas_inferiores_inmediatas.Add(area);
            }
            
          //  areas_inferiores_inmediatas.Add(nodo_padre.Area());
            return areas_inferiores_inmediatas;
        }

    }
}


