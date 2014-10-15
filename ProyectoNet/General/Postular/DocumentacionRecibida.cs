using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class DocumentacionRecibida
    {


        public int Id { get; set; }
        public ItemCv ItemCv { get; set; }
        public string Folio { get; set; }
        public int IdTabla { get; set; }
        //public Foliable Foliable { get { return _foliable; } set { _foliable = value; } }
        public DateTime Fecha { get; set; }


        public DocumentacionRecibida() { }

        public DocumentacionRecibida(int id, string folio, Foliable foliable, DateTime fecha) {
           // Id = id;
           // ItemCv = folio;
            //_foliable = foliable;
            //Fecha = fecha;
        }

        public int IdItemCV { get { return ItemCv.Id; } set { } }
       
    }
}
