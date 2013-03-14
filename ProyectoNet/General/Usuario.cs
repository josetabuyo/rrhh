using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;

namespace General
{
    public class Usuario : Persona
    {
 

        private string _NombreDeUsuario;
        public string NombreDeUsuario
        {
            get { return _NombreDeUsuario; }
            set { _NombreDeUsuario = value;  }
        }

        public List<Area> Areas { get; set; }
        public Usuario()
        {
            this.Areas = new List<Area>();
            this.TienePermisosParaViaticos = false;
            this.TienePermisosParaSiCoI = false;
            this.TienePermisosParaSACC = false;
        }

        public bool EsFirmante { get; set; }
             
        //public List<int> FuncionalidadesPermitidas { get; set; }

        public bool TienePermisosParaSACC { get; set; }
        public bool TienePermisosParaSiCoI { get; set; }
        public bool TienePermisosParaViaticos { get; set; }

    }
}
