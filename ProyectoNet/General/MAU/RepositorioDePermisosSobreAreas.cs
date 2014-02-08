using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDePermisosSobreAreas : RepositorioLazy<List<KeyValuePair<int, int>>>, IRepositorioDePermisosSobreAreas
    {
        protected IConexionBD conexion;
        private RepositorioDeAreas repositorioDeAreas;

        public RepositorioDePermisosSobreAreas(IConexionBD conexion, RepositorioDeAreas repo_areas)
        {
            this.conexion = conexion;
            this.repositorioDeAreas = repo_areas;
            this.cache = new CacheNoCargada<List<KeyValuePair<int, int>>>();
        }

        List<Area> IRepositorioDePermisosSobreAreas.AreasAdministradasPor(Usuario usuario)
        {
            return AreasAdministradasPor(usuario.Id);
        }

        public List<KeyValuePair<int, int>> ObtenerTodosLosPermisosDesdeLaBase()
        {
            return conexion.Ejecutar("dbo.MAU_GetPermisosSobreAreas")
                .Rows.Select(row => new KeyValuePair<int, int>(row.GetSmallintAsInt("id_usuario"), row.GetSmallintAsInt("id_area")))
                .ToList();
        }

        public List<Area> AreasAdministradasPor(int id_usuario)
        {
            var permisos = cache.Ejecutar(ObtenerTodosLosPermisosDesdeLaBase, this);
            return permisos.FindAll(p => p.Key == id_usuario).Select(p => this.repositorioDeAreas.GetAreaPorId(p.Value)).ToList();
        }

        public void AsignarAreaAUnUsuario(Usuario usuario, Area area)
        {
            this.AsignarAreaAUnUsuario(usuario.Id, area.Id);
        }

        public void AsignarAreaAUnUsuario(int id_usuario, int id_area)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", id_usuario);
            parametros.Add("@id_area", id_area);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_AsignarAreaAUsuario", parametros);
        }
        public void DesAsignarAreaAUnUsuario(Usuario usuario, Area area)
        {
            this.DesAsignarAreaAUnUsuario(usuario.Id, area.Id);
        }

        public void DesAsignarAreaAUnUsuario(int id_usuario, int id_area)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", id_usuario);
            parametros.Add("@id_area", id_area);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_DesAsignarAreaAUsuario", parametros);
        }
    }
}
