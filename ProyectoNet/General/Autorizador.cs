using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Autorizador
    {
        protected List<MenuDelSistema> menues_del_sistema;
        public Autorizador(List<MenuDelSistema> menues_del_sistema)
        {
            this.menues_del_sistema = menues_del_sistema;
        }

        public List<ItemDeMenu> ItemsPermitidos(string nombre_menu)
        {
            var menu = menues_del_sistema.Find(m => m.SeLlama(nombre_menu));
            if (menu == null) menu = MenuDelSistema.MenuNulo();
            return menu.Items();
        }
    }
}
