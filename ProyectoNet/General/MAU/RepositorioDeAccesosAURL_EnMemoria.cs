using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class RepositorioDeAccesosAURL_EnMemoria:IRepositorioDeAccesosAURL
    {
        private List<AccesoAURL> accesos;
        public RepositorioDeAccesosAURL_EnMemoria(List<AccesoAURL> accesos)
        {
            this.accesos = accesos;
        }

        public List<AccesoAURL> TodosLosAccesos()
        {
            return this.accesos;
        }
    }
}
