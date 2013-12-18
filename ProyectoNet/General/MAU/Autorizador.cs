using System.Collections.Generic;
using System.Linq;
using ExtensionesDeLista;
using General;
using System;
using System.Security.Cryptography;
using System.Text;
using General.MAU;

namespace AdministracionDeUsuarios
{
    public class Autorizador
    {

        protected Dictionary<Usuario, List<Funcionalidad>> permisos;
        protected Dictionary<Usuario, List<Area>> areas;
        protected Dictionary<Funcionalidad, List<string>> enlaces;
        protected IRepositorioDeUsuarios repositorio_usuarios { get; set; }

        public Autorizador(Dictionary<Usuario, List<Funcionalidad>> permisos, IRepositorioDeUsuarios repo_usuarios)
        {
            this.permisos = permisos;
            this.repositorio_usuarios = repo_usuarios;
        }

        public Autorizador()
        {
        }

        public bool PuedeAcceder(Usuario usuario, Funcionalidad funcionalidad)
        {
            List<Funcionalidad> permisos_usuario;
            if (!this.permisos.TryGetValue(usuario, out permisos_usuario)) return false;
            return permisos_usuario.Exists(f => f.Equals(funcionalidad));
        }

        public bool PuedeAcceder(Usuario usuario, string nombre_funcionalidad)
        {
            List<Funcionalidad> permisos_usuario;
            if (!this.permisos.TryGetValue(usuario, out permisos_usuario)) return false;
            return permisos_usuario.Exists(f => f.Nombre==nombre_funcionalidad);
        }

        public void ConcederPermisoA(Usuario usuario, Funcionalidad funcionalidad)
        {
            if(PuedeAcceder(usuario, funcionalidad)) return;
            List<Funcionalidad> permisos_usuario;
            if (!this.permisos.TryGetValue(usuario, out permisos_usuario)) {
                permisos_usuario = new List<Funcionalidad>();
                this.permisos.Add(usuario, permisos_usuario);
            };            
            permisos_usuario.Add(funcionalidad);
        }

        //public void DenegarPermisoA(string usuario, Funcionalidad funcionalidad)
        //{
        //    var permiso = Permiso.Denegar(funcionalidad);
        //    FuncionalidadDelUsuario(usuario).RemoveAll(p => p.ActuaSobreLaMismaFuncionalidadQue(permiso));
        //    FuncionalidadDelUsuario(usuario).Add(permiso);
        //}

        //public List<Permiso> FuncionalidadDelUsuario(string usuario)
        //{
        //    if (!permisos.ContainsKey(usuario))
        //        permisos.Add(usuario, new List<Permiso>());
        //    return permisos[usuario];
        //}

        public static Autorizador Instancia()
        {
            return new Autorizador();
        }

        public List<General.Area> AreasAdministradasPor(Usuario usuario)
        {
            var areas_usuario = new List<Area>();
            this.areas.TryGetValue(usuario, out areas_usuario);
            return areas_usuario;
        }

        public void AsignarAreaAUnUsuario(Usuario usuario, Area area)
        {
            List<Area> areas_usuario;
            if (!this.areas.TryGetValue(usuario, out areas_usuario))
            {
                areas_usuario = new List<Area>();
                this.areas.Add(usuario, areas_usuario);
            };
            areas_usuario.Add(area);
        }

        public bool Login(string nombre_usuario, string clave)
        {
            var usuario = this.repositorio_usuarios.GetUsuarioPorAlias(nombre_usuario);
            return usuario.ValidarClave(clave);
        }

        public List<string> EnlacesMenu(string nombre_menu, Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
