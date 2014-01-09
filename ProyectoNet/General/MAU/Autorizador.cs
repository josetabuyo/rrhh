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

        protected IRepositorioDeFuncionalidades repositorio_funcionalidades;
        protected IRepositorioDePermisosSobreAreas repositorio_permisos_sobre_areas;
        protected List<MenuDelSistema> menues;
        protected IRepositorioDeUsuarios repositorio_usuarios;
        protected List<AccesoAURL> accesos_a_urls;

        public Autorizador(IRepositorioDeFuncionalidades repo_funcionalidades, List<MenuDelSistema> menues, IRepositorioDeUsuarios repo_usuarios, IRepositorioDePermisosSobreAreas repo_permisos_sobre_areas, List<AccesoAURL> accesos_a_urls)
        {
            this.repositorio_funcionalidades = repo_funcionalidades;
            this.menues = menues;
            this.repositorio_usuarios = repo_usuarios;
            this.repositorio_permisos_sobre_areas = repo_permisos_sobre_areas;
            this.accesos_a_urls = accesos_a_urls;
        }

        public Autorizador()
        {
        }

        public bool ElUsuarioTienePermisosPara(Usuario usuario, Funcionalidad funcionalidad)
        {
            return this.repositorio_funcionalidades.FuncionalidadesPara(usuario).Exists(f => f.Equals(funcionalidad));
        }

        public bool ElUsuarioTienePermisosPara(Usuario usuario, string nombre_funcionalidad)
        {
            return this.repositorio_funcionalidades.FuncionalidadesPara(usuario).Exists(f => f.Nombre == nombre_funcionalidad);
        }

        public void ConcederFuncionalidadA(Usuario usuario, Funcionalidad funcionalidad)
        {
            this.repositorio_funcionalidades.ConcederFuncionalidadA(usuario, funcionalidad);           
        }

        public static Autorizador Instancia()
        {
            return new Autorizador();
        }

        public List<Area> AreasAdministradasPor(Usuario usuario)
        {
            return repositorio_permisos_sobre_areas.AreasAdministradasPor(usuario);
        }

        public void AsignarAreaAUnUsuario(Usuario usuario, Area area)
        {
            repositorio_permisos_sobre_areas.AsignarAreaAUnUsuario(usuario, area);
        }

        public bool Login(string nombre_usuario, string clave)
        {
            var usuario = this.repositorio_usuarios.GetUsuarioPorAlias(nombre_usuario);
            return usuario.ValidarClave(clave);
        }

        public MenuDelSistema GetMenuPara(string nombre_menu, Usuario usuario)
        {
            return menues.Find(m => m.SeLlama(nombre_menu)).FitrarPorFuncionalidades(repositorio_funcionalidades.FuncionalidadesPara(usuario));
        }

        public Boolean ElUsuarioPuedeAccederALaURL(Usuario usuario, string url)
        {
            var funcionalidades_que_permiten_acceder_a_la_url = this.accesos_a_urls.FindAll(a => a.Url == url).Select(a=> a.Funcionalidad);
            return this.repositorio_funcionalidades.FuncionalidadesPara(usuario).Any(f => funcionalidades_que_permiten_acceder_a_la_url.Contains(f));
        }
    }
}
