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
        public ItemDeMenu(int id, string menu, int orden, string nombre_item, string url, int padre)
        {
            this.Id = id;
            this.Menu = menu;
            this.Orden = orden;
            this.NombreItem = nombre_item;
            this.Url = url;
            this.Padre = padre;
        }

        public string Menu { get; set; }
        public int Id { get; set; }
        public int Orden { get; set; }
        public string NombreItem { get; set; }
        public string Url { get; set; }
        public int Padre { get; set; }
    }
}
