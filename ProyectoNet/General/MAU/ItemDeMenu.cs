using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdministracionDeUsuarios
{
    public class ItemDeMenu
    {
        public Funcionalidad Funcionalidad { get; set; }
        public int Orden { get; set; }
        public string NombreItem { get; set; }
        public string Url { get; set; }  

        public ItemDeMenu()
        {

        }

        public ItemDeMenu(int orden, string nombre_item, string url, Funcionalidad funcionalidad)
        {
            this.Orden = orden;
            this.NombreItem = nombre_item;
            this.Url = url;
            this.Funcionalidad = funcionalidad;
        }      
    }
}
