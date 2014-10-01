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
        protected string _itemCV;

        public int Id { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public string ItemCV { get { return _itemCV; } set { _itemCV = value; } }

        public FoliableAntecedentesPenales()
        {
        }

        public FoliableAntecedentesPenales(string descripcion, string item)
        {
            _itemCV = item;
            _descripcion = descripcion;
        }

        public override List<Foliable> documentacion(CurriculumVitae cv)
        {
            FoliableAntecedentesPenales foliable = new FoliableAntecedentesPenales();
            foliable.Id = 1;
            foliable.Descripcion = "Antecedentes Penales";

            return new List<Foliable>() { foliable };// foliable;
        }

        public override int tabla()
        {
            return 1;
        }
    }
}
