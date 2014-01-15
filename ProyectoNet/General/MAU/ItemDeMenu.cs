using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class ItemDeMenu
    {
        public int Id { get; set; }
        public int Orden { get; set; }
        public string NombreItem { get; set; }
        public string Descripcion { get; set; }
        public AccesoAURL Acceso { get; set; }

        public ItemDeMenu()
        {

        }

        public ItemDeMenu(int orden, string nombre_item, AccesoAURL acceso, String descripcion = "")
        {
            this.Orden = orden;
            this.NombreItem = nombre_item;
            this.Acceso = acceso;
            this.Descripcion = descripcion;
        }
    }
}
