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

        public void AsignarAreaAUnUsuario(Usuario usuario, Area area, int id_usuario_logueado)
        {
            if (diccionario_de_areas.ContainsKey(usuario))
            {
                diccionario_de_areas[usuario].Add(area);
            }
            else
            {
                diccionario_de_areas.Add(usuario, new List<Area>(){area});
            }
        }

        public void DesAsignarAreaAUnUsuario(Usuario usuario, Area area, int id_usuario_logueado)
        {
            diccionario_de_areas[usuario].Remove(area);
        }


        public void AsignarAreaAUnUsuario(int id_usuario, int id_area, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }

        public void DesAsignarAreaAUnUsuario(int id_usuario, int id_area, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }


        public List<Usuario> UsuariosQueAdministranElArea(Area area)
        {
            throw new NotImplementedException();
        }
    }
}
