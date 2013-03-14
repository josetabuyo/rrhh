namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BuscadorDeAreas
    {
        public List<Area> areas;


        public BuscadorDeAreas(List<Area> areas)
        {
            this.areas = areas;
        }

        public List<Area> Buscar(FiltroDeAreas filtro)
        {
            return areas.FindAll(area => filtro.aplicaPara(area));
        }
    }
}
