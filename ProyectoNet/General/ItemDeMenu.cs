using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class ItemDeMenu
    {
        public ItemDeMenu()
        {

        }
        public ItemDeMenu(int id, int orden, string nombre_item, string url, int nivel)
        {
            this.Id = id;
            this.Orden = orden;
            this.NombreItem = nombre_item;
            this.Url = url;
            this.Nivel = nivel;
        }

        public int Id { get; set; }
        public int Orden { get; set; }
        public string NombreItem { get; set; }
        public string Url { get; set; }
        public int Nivel { get; set; }
    }
}
