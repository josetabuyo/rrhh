using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensionesDeLista;

namespace AdministracionDeUsuarios
{
    public class Autorizador
    {
        /// <summary>
        /// ejemplo
        /// { "juan", { Permiso("Concedido", Funcionalidad("lectura_legajos")), Permiso("Denegado", Funcionalidad("escritura_legajos")) } }
        /// </summary>
        protected Dictionary<string, List<Permiso>> permisos;

        public Autorizador(Dictionary<string, List<Permiso>> permisos)
        {
            this.permisos = permisos;
        }

        public bool PuedeAcceder(string usuario, Funcionalidad funcionalidad)
        {
            var permiso = PermisoPara(usuario, funcionalidad, permisos[usuario]);
            return permiso.Permite();
        }

        protected Permiso PermisoPara(string usuario, Funcionalidad funcionalidad, List<Permiso> permisos)
        {
            var permisos_mas_especificos_que_this = permisos.FindAll(
                    permiso => permiso.EsPara(funcionalidad), Permiso.Null());
            permisos_mas_especificos_que_this.Sort((p1, p2) => { return p2.GradoDeEspecificidad() - p1.GradoDeEspecificidad(); });
            var permiso_mas_especifico_que_this = permisos_mas_especificos_que_this.First();
            return permiso_mas_especifico_que_this.PermisoEspecifico(funcionalidad);
        }

        public bool ConcederPermisoA(string usuario, Funcionalidad funcionalidad)
        {
            FuncionalidadDelUsuario(usuario).Add(Permiso.Conceder(funcionalidad));
            return true;
        }

        public void DenegarPermisoA(string usuario, Funcionalidad funcionalidad)
        {
            FuncionalidadDelUsuario(usuario).Add(Permiso.Denegar(funcionalidad));
        }

        protected List<Permiso> FuncionalidadDelUsuario(string usuario)
        {
            if (!permisos.ContainsKey(usuario))
                permisos.Add(usuario, new List<Permiso>());
            return permisos[usuario];
        }
    }
}
