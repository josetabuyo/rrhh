using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    class TransicionesDeAreas
    {
        public Area area_superior;
        public Area area_dependiente;

        public TransicionesDeAreas(Area area_dependiente, Area area_superior)
        {
            this.area_superior = area_superior;
            this.area_dependiente = area_dependiente;
        }
    }
}
