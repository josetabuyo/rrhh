using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class ItemCv
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdTabla { get; set; }

        public ItemCv(int id_item, string descripcion, int id_tabla) {
            this.Id = id_item;
            this.Descripcion = descripcion;
            this.IdTabla = id_tabla;
        }

        public ItemCv() { }
    }
}
