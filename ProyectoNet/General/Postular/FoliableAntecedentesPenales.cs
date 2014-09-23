using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class FoliableAntecedentesPenales : Foliable
    {
        protected int _id;
        protected string _descripcion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }

        public FoliableAntecedentesPenales()
        {
        }

        public FoliableAntecedentesPenales(string descripcion)
        {
            _descripcion = descripcion;
        }

        public override List<Foliable> documentacion(CurriculumVitae cv)
        {
            Foliable foliable = new FoliableAntecedentesPenales();
            return new List<Foliable>();// foliable;
        }

        public override int tabla()
        {
            return 1;
        }
    }
}
