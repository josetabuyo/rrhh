using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class RepositorioDeMenues_EnMemoria:IRepositorioDeMenues
    {
        private List<MenuDelSistema> menues;
        public RepositorioDeMenues_EnMemoria(List<MenuDelSistema> menues)
        {
            this.menues= menues;
        }

        public List<MenuDelSistema> TodosLosMenues()
        {
            return this.menues;
        }
    }    
}
