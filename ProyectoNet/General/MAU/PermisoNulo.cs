using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdministracionDeUsuarios
{
    public class PermisoNulo:Permiso
    {
        public PermisoNulo()
            : base("Nulo", new Funcionalidad("nula", 0), new List<Permiso>())
        {
        }

        public override bool Permite()
        {
            return false;
        }

        public override Permiso PermisoEspecifico(Funcionalidad funcionalidad)
        {
            return Permiso.Null();
        }

        public override int GradoDeEspecificidad()
        {
            return 9999;
        }
    }
}
