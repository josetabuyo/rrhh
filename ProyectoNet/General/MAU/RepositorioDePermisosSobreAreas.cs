using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;


namespace General.MAU
{
    public class RepositorioDePermisosSobreAreas:IRepositorioDePermisosSobreAreas
    {
        private Dictionary<Usuario, List<Area>> diccionario_de_areas;

        public RepositorioDePermisosSobreAreas(Dictionary<Usuario, List<Area>> diccionario_de_areas)
        {
            // TODO: Complete member initialization
            this.diccionario_de_areas = diccionario_de_areas;
        }
        public List<Area> AreasAdministradasPor(Usuario usuario)
        {
            return diccionario_de_areas.GetValueOrDefault(usuario, new List<Area>());
            //return diccionario_de_areas[usuario];
            //throw new NotImplementedException();
        }


        public Area AsignarAreaAUnUsuario(Usuario usuario, Area area)
        {
            return area;
        }
    }
}
