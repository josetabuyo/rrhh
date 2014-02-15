using System.Collections.Generic;
using System.Linq;
using ExtensionesDeLista;
using General;
using System;
using System.Security.Cryptography;
using System.Text;

namespace General.MAU
{
    public class Autorizador
    {
        protected IRepositorioDeFuncionalidadesDeUsuarios repositorio_funcionalidades_usuarios;
        protected IRepositorioDePermisosSobreAreas repositorio_permisos_sobre_areas;
        protected IRepositorioDeMenues repositorio_menues;
        protected IRepositorioDeUsuarios repositorio_usuarios;
        protected IRepositorioDeAccesosAURL repositorio_accesos_a_url;

        public Autorizador(IRepositorioDeFuncionalidadesDeUsuarios repo_funcionalidades,
            IRepositorioDeMenues repo_menues,
            IRepositorioDeUsuarios repo_usuarios,
            IRepositorioDePermisosSobreAreas repo_permisos_sobre_areas,
            IRepositorioDeAccesosAURL repo_accesos_a_url)
        {
            this.repositorio_funcionalidades_usuarios = repo_funcionalidades;
            this.repositorio_menues = repo_menues;
            this.repositorio_usuarios = repo_usuarios;
            this.repositorio_permisos_sobre_areas = repo_permisos_sobre_areas;
            this.repositorio_accesos_a_url = repo_accesos_a_url;
        }

        public Autorizador()
        {
        }

        public bool ElUsuarioTienePermisosPara(Usuario usuario, Funcionalidad funcionalidad)
        {
            return this.repositorio_funcionalidades_usuarios.FuncionalidadesPara(usuario).Exists(f => f.Equals(funcionalidad));
        }

        public bool ElUsuarioTienePermisosPara(Usuario usuario, string nombre_funcionalidad)
        {
            return this.repositorio_funcionalidades_usuarios.FuncionalidadesPara(usuario).Exists(f => f.Nombre == nombre_funcionalidad);
        }


        public bool ElUsuarioTienePermisosPara(int id_usuario, int id_funcionalidad)
        {
            return this.repositorio_funcionalidades_usuarios.FuncionalidadesPara(id_usuario).Exists(f => f.Id==id_funcionalidad);
        }


        public void ConcederFuncionalidadA(Usuario usuario, Funcionalidad funcionalidad)
        {
            this.repositorio_funcionalidades_usuarios.ConcederFuncionalidadA(usuario, funcionalidad);
        }

        public void ConcederFuncionalidadA(int id_usuario, int id_funcionalidad)
        {
            this.repositorio_funcionalidades_usuarios.ConcederFuncionalidadA(id_usuario, id_funcionalidad);
        }

        public void DenegarFuncionalidadA(int id_usuario, int id_funcionalidad)
        {
            this.repositorio_funcionalidades_usuarios.DenegarFuncionalidadA(id_usuario, id_funcionalidad);
        }

        public static Autorizador Instancia()
        {
            return new Autorizador();
        }

        public List<Area> AreasAdministradasPor(Usuario usuario)
        {
            return repositorio_permisos_sobre_areas.AreasAdministradasPor(usuario);
        }

        public List<Area> AreasAdministradasPor(int id_usuario)
        {
            return repositorio_permisos_sobre_areas.AreasAdministradasPor(id_usuario);
        }

        public void AsignarAreaAUnUsuario(Usuario usuario, Area area)
        {
            repositorio_permisos_sobre_areas.AsignarAreaAUnUsuario(usuario, area);
        }

        public void DesAsignarAreaAUnUsuario(Usuario usuario, Area area)
        {
            repositorio_permisos_sobre_areas.DesAsignarAreaAUnUsuario(usuario, area);
        }

        public bool Login(string nombre_usuario, string clave)
        {
            var usuario = this.repositorio_usuarios.GetUsuarioPorAlias(nombre_usuario);
            return usuario.ValidarClave(clave);
        }

        public MenuDelSistema GetMenuPara(string nombre_menu, Usuario usuario)
        {
            return repositorio_menues.TodosLosMenues().Find(m => m.SeLlama(nombre_menu)).FitrarPorFuncionalidades(repositorio_funcionalidades_usuarios.FuncionalidadesPara(usuario));
        }

        public Boolean ElUsuarioPuedeAccederALaURL(Usuario usuario, string url)
        {
            var funcionalidades_que_permiten_acceder_a_la_url = this.repositorio_accesos_a_url.TodosLosAccesos().FindAll(a => a.Url.ToUpper() == url.ToUpper()).Select(a => a.Funcionalidad);
            if (funcionalidades_que_permiten_acceder_a_la_url.Count() == 0) return true;
            return this.repositorio_funcionalidades_usuarios.FuncionalidadesPara(usuario).Any(f => funcionalidades_que_permiten_acceder_a_la_url.Contains(f));
        }

        public void AsignarAreaAUnUsuario(int id_usuario, int id_area)
        {
            repositorio_permisos_sobre_areas.AsignarAreaAUnUsuario(id_usuario, id_area);
        }

        public void DesAsignarAreaAUnUsuario(int id_usuario, int id_area)
        {
            repositorio_permisos_sobre_areas.DesAsignarAreaAUnUsuario(id_usuario, id_area);
        }

    }
}
