using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class TipoTicket
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string urlComponente { get; set; }
        public int idFuncionalidad { get; set; }

        public TipoTicket()
        { }

        public TipoTicket(int id, string codigo, string descripcion, string url, int idFuncionalidad)
        {
            this.descripcion = descripcion;
            this.id = id;
            this.urlComponente = url;
            this.idFuncionalidad = idFuncionalidad;
            this.codigo = codigo;
        }
    }
}
