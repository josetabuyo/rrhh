using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class VinculoCredencial
    {
        public int Id;
        public string Descripcion;
        public VinculoCredencial()
        {

        }

        public VinculoCredencial(int id, string desc)
        {
            this.Id = id;
            this.Descripcion = desc;
        }
    }
}
