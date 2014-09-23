using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public abstract class Foliable
    {
        public Foliable() { }

        public abstract List<Foliable> documentacion(CurriculumVitae cv);

        public abstract int tabla();

    }
}
