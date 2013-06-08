using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class MenuDelSistema
    {
        protected string nombre;
        protected List<ItemDeMenu> items;

        public MenuDelSistema(string nombre, List<ItemDeMenu> items)
        {
            this.nombre = nombre;
            this.items = items;
        }

        public List<ItemDeMenu> Items()
        {
            return items;
        }

        public bool SeLlama(string nombre_menu)
        {
            return nombre_menu.Equals(this.nombre);
        }

        public static MenuDelSistema MenuNulo()
        {
            return new MenuDelSistema("", new List<ItemDeMenu>());
        }
    }
}
