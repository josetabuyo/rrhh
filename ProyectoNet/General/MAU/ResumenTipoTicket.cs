using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class ResumenTipoTicket
    {
        public string DescripcionTipo;
        public int CantidadTickets;
        public ResumenTipoTicket()
        {

        }
        public ResumenTipoTicket(string p, int p_2)
        {
            // TODO: Complete member initialization
            this.DescripcionTipo = p;
            this.CantidadTickets = p_2;
        }
    }
}
