using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;

namespace General
{
    public class ResponsableDDJJ
    {
        IRepositorioDePermisosSobreAreas repositorio;

        public ResponsableDDJJ(IRepositorioDePermisosSobreAreas un_repo)
        {
            repositorio = un_repo;
        }

        public List<Area> AreasConDDJJAdministradasPor(Usuario usuario)
        {
            return repositorio.AreasAdministradasPor(usuario).FindAll(area => area.PresentaDDJJ);

        }

    }
}
