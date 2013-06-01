using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class MenuDelSistema
    {
        protected string nombre;
        protected Dictionary<string, string> items;

        public MenuDelSistema(string nombre, Dictionary<string, string> items)
        {
            this.nombre = nombre;
            this.items = items;
        }

        public Dictionary<string, string> Items()
        {
            return items;
        }

        public bool SeLlama(string nombre_menu)
        {
            return nombre_menu.Equals(this.nombre);
        }

        public static MenuDelSistema MenuNulo()
        {
            return new MenuDelSistema("", new Dictionary<string, string>());
        }
    }
}
