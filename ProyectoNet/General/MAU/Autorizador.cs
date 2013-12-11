using System.Collections.Generic;
using System.Linq;
using ExtensionesDeLista;
using General;

namespace AdministracionDeUsuarios
{
    public class Autorizador
    {

        protected Dictionary<Usuario, List<Funcionalidad>> permisos;
        protected Dictionary<Usuario, List<Area>> areas;

        public Autorizador(Dictionary<Usuario, List<Funcionalidad>> permisos)
        {
            this.permisos = permisos;
        }

        public Autorizador()
        {
            // TODO: Complete member initialization
        }

        public bool PuedeAcceder(Usuario usuario, Funcionalidad funcionalidad)
        {
            var permisos_usuario = new List<Funcionalidad>();
            if (!this.permisos.TryGetValue(usuario, out permisos_usuario)) return false;
            return permisos_usuario.Exists(p => p.Equals(funcionalidad));
        }



        //public bool ConcederPermisoA(string usuario, Funcionalidad funcionalidad)
        //{
        //    var permiso = Permiso.Conceder(funcionalidad);
        //    FuncionalidadDelUsuario(usuario).RemoveAll(p => p.ActuaSobreLaMismaFuncionalidadQue(permiso));
        //    FuncionalidadDelUsuario(usuario).Add(permiso);
        //    return true;
        //}

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
    }
}
