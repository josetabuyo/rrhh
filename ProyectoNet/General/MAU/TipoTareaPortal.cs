using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class TipoTareaPortal
    {
        //public int Id { get; set; }
        //public string Nombre { get; set; }

        public int id { get; set; }
        public string descripcion { get; set; }
        public string urlComponente { get; set; }
        public int idFuncionalidad { get; set; }

        public TipoTareaPortal()
        { }

        public TipoTareaPortal(int id, string descripcion, string url, int idFuncionalidad)
        {
            this.descripcion = descripcion;
            this.id = id;
            this.urlComponente = url;
            this.idFuncionalidad = idFuncionalidad;

        }
    }
}
