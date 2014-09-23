using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class FoliableExperienciaLaboralPrivada : Foliable 
    {
        protected string _descripcion;

        public virtual string Descripcion { get { return _descripcion; } set { _descripcion = value; } }

        public FoliableExperienciaLaboralPrivada()
        {
        }

        public FoliableExperienciaLaboralPrivada(string descripcion)
        {
            _descripcion = descripcion;
        }

        public override List<Foliable> documentacion(CurriculumVitae cv)
        {
            return new List<Foliable>();
           
        }

        public override int tabla()
        {
            return 2;
        }

    }
}
