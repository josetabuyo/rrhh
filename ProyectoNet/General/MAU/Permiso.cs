using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensionesDeLista;

namespace AdministracionDeUsuarios
{
    public class Permiso
    {
        /// <summary>
        /// ejemplos:
        /// "Concedido", "Denegado"
        /// </summary>
        public string tipo;
        public Funcionalidad funcionalidad;
        public List<Permiso> sub_permisos;
        public int profundidad_en_el_arbol;

        public static string CONCEDIDO = "Concedido";
        public static string DENEGADO = "Denegado";

        public Permiso()
        {
        }

        public Permiso(string tipo, Funcionalidad funcionalidad, List<Permiso> sub_permisos)
        {
            this.tipo = tipo;
            this.funcionalidad = funcionalidad;
            this.sub_permisos = sub_permisos;
        }

        public static Permiso Conceder(Funcionalidad funcionalidad)
        {
            return CrearPermiso(Permiso.CONCEDIDO, funcionalidad);
        }

        public static Permiso Denegar(Funcionalidad funcionalidad)
        {
            return CrearPermiso(Permiso.DENEGADO, funcionalidad);
        }

        public bool EsPara(Funcionalidad funcionalidad)
        {
            return this.funcionalidad.Equals(funcionalidad) || this.sub_permisos.Any(p => p.EsPara(funcionalidad));
        }

        public List<Permiso> AddSubPermisosA(List<Permiso> lista_permisos)
        {
            this.sub_permisos.ForEach((p) =>
            {
                lista_permisos.Add(p);
                p.AddSubPermisosA(lista_permisos);
            });
            return lista_permisos;
        }

        protected static Permiso CrearPermiso(string tipo, Funcionalidad funcionalidad)
        {
            var permiso = new Permiso(tipo, funcionalidad, funcionalidad.PropagarPermiso(tipo));
            return permiso;
        }

        public bool ActuaSobreLaMismaFuncionalidadQue(Permiso permiso)
        {
            return permiso.EsPara(this.funcionalidad);
        }

        public void AgregaTuFuncionalidadA(List<Funcionalidad> funcionalidades)
        {
            funcionalidades.Add(this.funcionalidad);
        }

        public Permiso PermisoMasEspecificoPara(Funcionalidad funcionalidad)
        {
            var permiso_mas_especifico_que_this = this.sub_permisos.Find(permiso => permiso.EsPara(funcionalidad), () => { return this; });
            if (permiso_mas_especifico_que_this.EsPara(funcionalidad))
                return permiso_mas_especifico_que_this;
            return Permiso.Null();
        }

        public virtual bool Permite()
        {
            return this.tipo.Equals(Permiso.CONCEDIDO);
        }

        public static Permiso Null()
        {
            return new PermisoNulo();
        }

        virtual public Permiso PermisoEspecifico(Funcionalidad funcionalidad)
        {
            return PermisoMasEspecificoPara(funcionalidad);
        }

        public override string ToString()
        {
            return this.funcionalidad.ToString() + ":" + this.tipo;
        }

        virtual public int GradoDeEspecificidad()
        {
            return this.funcionalidad.GradoDeEspecificidad();
        }
    }
}
