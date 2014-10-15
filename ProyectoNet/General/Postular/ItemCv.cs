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
        public ItemCv(int id_item, string descripcion) {
            this.Id = id_item;
            this.Descripcion = descripcion;
        }

        public ItemCv() { }
    }
}
