using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvCapacidadPersonal:ItemCv
    {
        protected int _id;
        protected int _tipo;
        protected string _detalle;

        public int Id { get { return _id; } set { _id = value; } }
        public int Tipo { get { return _tipo; } set { _tipo = value; } }
        public string Detalle { get { return _detalle; } set { _detalle = value; } }

        public CvCapacidadPersonal(int id, int tipo, string detalle):base(id,detalle)
        {
            this._id = id;
            this._tipo = tipo;
            this._detalle = detalle;
        }

        public CvCapacidadPersonal()
        {
        }
    }
}
