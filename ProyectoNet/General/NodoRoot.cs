using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    class NodoRoot:Nodo
    {
        

        public NodoRoot(Area root):base(root)
        {
        
        }

        public override bool EsRoot()
        {
            return true;
        }

        internal override List<Area> AreasSuperiores()
        {
            return new List<Area>();
        }

        internal override List<Area> AreasInferioresInmediatasDe(Area root)
        {
            return new List<Area>();
        }
    }
}
