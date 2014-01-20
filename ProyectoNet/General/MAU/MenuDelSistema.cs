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
        public List<MenuDelSistema> SubMenues { get; set; }
        public int Id { get; set; }

        public MenuDelSistema()
        {
            this.Items = new List<ItemDeMenu>();
            this.SubMenues = new List<MenuDelSistema>();
        }

        public MenuDelSistema(string nombre, List<ItemDeMenu> items, List<MenuDelSistema> sub_menues)
        {
            this.Nombre = nombre;
            this.Items = items;
            this.SubMenues = sub_menues;
        }

        public bool SeLlama(string nombre_menu)
        {
            return nombre_menu.Equals(this.Nombre);
        }

        public static MenuDelSistema MenuNulo()
        {
            return new MenuDelSistema("", new List<ItemDeMenu>(), new List<MenuDelSistema>());
        }

        public MenuDelSistema FitrarPorFuncionalidades(List<Funcionalidad> funcionalidades)
        {
            var items_autorizados = this.Items.FindAll(i => funcionalidades.Contains(i.Acceso.Funcionalidad));
            var sub_menues_filtrados = new List<MenuDelSistema>();
            this.SubMenues.ForEach(sm=> sub_menues_filtrados.Add(sm.FitrarPorFuncionalidades(funcionalidades)));
            return new MenuDelSistema(this.Nombre, items_autorizados, sub_menues_filtrados);
        }
    }
}
