using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDePermisosSobreAreas : RepositorioLazySingleton<KeyValuePair<int, int>>, IRepositorioDePermisosSobreAreas
    {
        private static RepositorioDePermisosSobreAreas _instancia;
        private RepositorioDeAreas repositorioDeAreas;

        private RepositorioDePermisosSobreAreas(IConexionBD conexion, RepositorioDeAreas repo_areas)
            :base(conexion, 10)
        {
            this.repositorioDeAreas = repo_areas;
        }

        public static RepositorioDePermisosSobreAreas NuevoRepositorioDePermisosSobreAreas(IConexionBD conexion, RepositorioDeAreas repo_areas)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDePermisosSobreAreas(conexion, repo_areas);
            return _instancia;
        }

        List<Area> IRepositorioDePermisosSobreAreas.AreasAdministradasPor(Usuario usuario)
        {
            return AreasAdministradasPor(usuario.Id);
        }
        List<Usuario> IRepositorioDePermisosSobreAreas.UsuariosQueAdministranElArea(Area area)
        {
            return UsuariosQueAdministranElArea(area.Id);
        }

        public List<Usuario> UsuariosQueAdministranElArea(int id_area) {
            var repo_usuarios = new RepositorioDeUsuarios(conexion, RepositorioDePersonas.NuevoRepositorioDePersonas(conexion)); ;
            var permisos = this.Obtener();
            return permisos.FindAll(p => p.Value == id_area).Select(p => repo_usuarios.GetUsuarioPorId(p.Key)).ToList(); ;
        }


        public List<Area> AreasAdministradasPor(int id_usuario)
        {
            var permisos = this.Obtener();
            return permisos.FindAll(p => p.Key == id_usuario).Select(p => this.repositorioDeAreas.GetAreaPorId(p.Value)).ToList();
        }

        public void AsignarAreaAUnUsuario(Usuario usuario, Area area, int id_usuario_logueado)
        {
            this.AsignarAreaAUnUsuario(usuario.Id, area.Id, id_usuario_logueado);
        }

        public void AsignarAreaAUnUsuario(int id_usuario, int id_area, int id_usuario_logueado)
        {
            this.Guardar(new KeyValuePair<int, int>(id_usuario, id_area), id_usuario_logueado);
        }

        public void DesAsignarAreaAUnUsuario(Usuario usuario, Area area, int id_usuario_logueado)
        {
            this.DesAsignarAreaAUnUsuario(usuario.Id, area.Id, id_usuario_logueado);
        }

        public void DesAsignarAreaAUnUsuario(int id_usuario, int id_area, int id_usuario_logueado)
        {
            this.Quitar(new KeyValuePair<int, int>(id_usuario, id_area), id_usuario_logueado);
        }

        protected override List<KeyValuePair<int, int>> ObtenerDesdeLaBase()
        {
            return conexion.Ejecutar("dbo.MAU_GetPermisosSobreAreas")
                .Rows.Select(row => new KeyValuePair<int, int>(row.GetSmallintAsInt("id_usuario"), row.GetSmallintAsInt("id_area")))
                .ToList();
        }

        protected override void GuardarEnLaBase(KeyValuePair<int, int> objeto, int id_usuario_logueado)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", objeto.Key);
            parametros.Add("@id_area", objeto.Value);
            parametros.Add("@id_usuario_alta", id_usuario_logueado);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_AsignarAreaAUsuario", parametros);
        }

        protected override void QuitarDeLaBase(KeyValuePair<int, int> objeto, int id_usuario_logueado)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", objeto.Key);
            parametros.Add("@id_area", objeto.Value);
            parametros.Add("@id_usuario_baja", id_usuario_logueado);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_DesAsignarAreaAUsuario", parametros);
        }
    }
}
