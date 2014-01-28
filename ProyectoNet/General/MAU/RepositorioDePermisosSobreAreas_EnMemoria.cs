using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;


namespace General.MAU
{
    public class RepositorioDePermisosSobreAreas_EnMemoria:IRepositorioDePermisosSobreAreas
    {
        private Dictionary<Usuario, List<Area>> diccionario_de_areas;

        public RepositorioDePermisosSobreAreas_EnMemoria(Dictionary<Usuario, List<Area>> diccionario_de_areas)
        {
            this.diccionario_de_areas = diccionario_de_areas;
        }

        public List<Area> AreasAdministradasPor(Usuario usuario)
        {
            return diccionario_de_areas.GetValueOrDefault(usuario, new List<Area>());
        }

        public List<Area> AreasAdministradasPor(int id_usuario)
        {
            throw new NotImplementedException();
        }

        public Area AsignarAreaAUnUsuario(Usuario usuario, Area area)
        {
            return area;
        }
    }
}
