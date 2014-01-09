using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class ItemDeMenu
    {
        public int Orden { get; set; }
        public string NombreItem { get; set; }
        public AccesoAURL Acceso { get; set; }

        public ItemDeMenu()
        {

        }

        public ItemDeMenu(int orden, string nombre_item, AccesoAURL acceso)
        {
            this.Orden = orden;
            this.NombreItem = nombre_item;
            this.Acceso = acceso;
        }      
    }
}
