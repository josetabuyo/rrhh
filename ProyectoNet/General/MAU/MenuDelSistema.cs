using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdministracionDeUsuarios
{
    public class MenuDelSistema
    {
        protected string nombre;
        public List<ItemDeMenu> Items {get; set;}

        public MenuDelSistema()
        {

        }

        public MenuDelSistema(string nombre, List<ItemDeMenu> items)
        {
            this.nombre = nombre;
            this.Items = items;
        }

        public bool SeLlama(string nombre_menu)
        {
            return nombre_menu.Equals(this.nombre);
        }

        public static MenuDelSistema MenuNulo()
        {
            return new MenuDelSistema("", new List<ItemDeMenu>());
        }

        public MenuDelSistema FitrarPorFuncionalidades(List<Funcionalidad> funcionalidades)
        {
            return new MenuDelSistema(this.nombre, this.Items.FindAll(i => funcionalidades.Contains(i.Funcionalidad)));
        }
    }
}
