using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class DocumentacionRecibida
    {


        public int Id { get; set; }
        public ItemCv ItemCV { get; set; }
        public string Folio { get; set; }
        public int IdPostulacion { get; set; }
        //public Foliable Foliable { get { return _foliable; } set { _foliable = value; } }
        public DateTime Fecha { get; set; }


        public DocumentacionRecibida() { }

        public DocumentacionRecibida(int id, ItemCv item_del_cv, string folio, int id_postulacion, DateTime fecha) {
            Id = id;
            ItemCV = item_del_cv;
            Folio = folio;
            Fecha = fecha;
            IdPostulacion = id_postulacion;
            //_foliable = foliable;
        }

        public int IdItemCV { get { return ItemCV.Id; } set { } }
        public int IdTabla { get { return ItemCV.IdTabla; } set { } }
       
    }
}
