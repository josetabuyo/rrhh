using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class DocumentacionRecibida
    {
        protected int _id;
        protected string _folio;
        protected Foliable _foliable;
        protected DateTime _fecha;

        public int Id { get { return _id; } set { _id = value; } }
        public string Folio { get { return _folio; } set { _folio = value; } }
        public Foliable Foliable { get { return _foliable; } set { _foliable = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }


        public DocumentacionRecibida() { }

        public DocumentacionRecibida(int id, string folio, Foliable foliable, DateTime fecha) {
            _id = id;
            _folio = folio;
            _foliable = foliable;
            _fecha = fecha;
        }
    }
}
