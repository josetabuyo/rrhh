using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class MenuDelSistema
    {
        public string Nombre { get; set; }
        public List<ItemDeMenu> Items { get; set; }
        public int Id { get; set; }

        public MenuDelSistema()
        {
            this.Items = new List<ItemDeMenu>();
        }

        public MenuDelSistema(string nombre, List<ItemDeMenu> items)
        {
            this.Nombre = nombre;
            this.Items = items;
        }

        public bool SeLlama(string nombre_menu)
        {
            return nombre_menu.Equals(this.Nombre);
        }

        public static MenuDelSistema MenuNulo()
        {
            return new MenuDelSistema("", new List<ItemDeMenu>());
        }

        public MenuDelSistema FitrarPorFuncionalidades(List<Funcionalidad> funcionalidades)
        {
            var items_autorizados = this.Items.FindAll(i => funcionalidades.Contains(i.Acceso.Funcionalidad));
            return new MenuDelSistema(this.Nombre, items_autorizados);
        }
    }
}
