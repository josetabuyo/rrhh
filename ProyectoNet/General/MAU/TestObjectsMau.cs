using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;
using General.MAU;
using General;

namespace AdministracionDeUsuarios
{
    public class TestObjectsMau
    {

        public static Usuario Jorge()
        {
            return new Usuario(1, "jorge", "l3WIqH4QWCAycWcSzPXYXRil/M8="); // pass = web1
        }

        public static Usuario Javier()
        {
            return new Usuario(2, "javier", "l3WIqH4QWCAycWcSzPXYXRil/M8="); // pass = web1
        }

        public static Usuario Zambri()
        {
            return new Usuario(3, "zambri", "l3WIqH4QWCAycWcSzPXYXRil/M8="); // pass = web1
        }

        public static Dictionary<Usuario, List<Funcionalidad>> diccionario_permisos()
        {
            var diccionario = new Dictionary<Usuario, List<Funcionalidad>>();
            var permisos_jorge = new List<Funcionalidad>();
            permisos_jorge.Add(FuncionalidadIngresoMenuPrincipal());
            permisos_jorge.Add(FuncionalidadIngresoSacc());
            permisos_jorge.Add(FuncionalidadIngresoModi());

            var permisos_javier = new List<Funcionalidad>();
            permisos_javier.Add(FuncionalidadIngresoMenuPrincipal());
            permisos_javier.Add(FuncionalidadIngresoAdministracionDeAreas());

            diccionario.Add(Jorge(), permisos_jorge);
            diccionario.Add(Javier(), permisos_javier);
            return diccionario;
        }

        public static Dictionary<Usuario, List<Area>> diccionario_areas()
        {
            var diccionario = new Dictionary<Usuario, List<Area>>();
            var areas_javier = new List<Area>();
            areas_javier.Add(AreaDeLegajos());
            diccionario.Add(Javier(), areas_javier);

            diccionario.Add(new UsuarioNulo(), new List<Area>());
            return diccionario;
        }

        public static List<MenuDelSistema> menues()
        {
            var menues = new List<MenuDelSistema>();
            menues.Add(MenuPrincipal());
            return menues;
        }

        public static MenuDelSistema MenuPrincipal()
        {
            var items = new List<ItemDeMenu>();
            items.Add(new ItemDeMenu(1, "MACC", new AccesoAURL(1, FuncionalidadIngresoSacc(), URLInicioSacc()), "Módulo para administrar las asistencias de cursos"));
            items.Add(new ItemDeMenu(2, "MODI", new AccesoAURL(2, FuncionalidadIngresoModi(), URLInicioModi()), "Módulo para digitalizar legajos"));
            items.Add(new ItemDeMenu(3, "Administracion de Areas", new AccesoAURL(3, FuncionalidadIngresoAdministracionDeAreas(), URLInicioAdministracionDeAreas()), "Módulo para administrar áreas"));
            return new MenuDelSistema("PRINCIPAL", items);
        }

        public static List<AccesoAURL> ListaDeAccesosAUrls()
        {
            var lista = new List<AccesoAURL>();
            lista.Add(new AccesoAURL(1, FuncionalidadIngresoSacc(), URLInicioSacc()));
            lista.Add(new AccesoAURL(2, FuncionalidadIngresoModi(), URLInicioModi()));
            lista.Add(new AccesoAURL(3, FuncionalidadIngresoAdministracionDeAreas(), URLInicioAdministracionDeAreas()));
            lista.Add(new AccesoAURL(4, FuncionalidadIngresoMenuPrincipal(), URLMenuPrincipal()));
            return lista;
        }

        public static Autorizador Autorizador()
        {
            return new Autorizador(TestObjectsMau.RepositorioDeFuncionalidadesDeUsuarios(),
                TestObjectsMau.RepositorioDeMenues(), 
                TestObjectsMau.RepositorioDeUsuarios(), 
                TestObjectsMau.RepositorioDePermisosSobreAreas(),
                TestObjectsMau.RepositorioDeAccesosAURL());
        }

        private static IRepositorioDeFuncionalidadesDeUsuarios RepositorioDeFuncionalidadesDeUsuarios()
        {
            return new RepositorioDeFuncionalidadesDeUsuarios_EnMemoria(diccionario_permisos());
        }

        public static IRepositorioDeMenues RepositorioDeMenues()
        {
            return new RepositorioDeMenues_EnMemoria(menues());
        }

        public static IRepositorioDeFuncionalidades RepositorioDeFuncionalidades()
        {
            return new RepositorioDeFuncionalidades_EnMemoria(diccionario_permisos());
        }

        public static IRepositorioDePermisosSobreAreas RepositorioDePermisosSobreAreas()
        {
            return new RepositorioDePermisosSobreAreas_EnMemoria(diccionario_areas());
        }

        public static IRepositorioDeAccesosAURL RepositorioDeAccesosAURL()
        {
            return new RepositorioDeAccesosAURL_EnMemoria(TestObjectsMau.ListaDeAccesosAUrls());
        }

        public static IRepositorioDeUsuarios RepositorioDeUsuarios()
        {
            var lista_usuarios = new List<Usuario>();
            lista_usuarios.Add(Jorge());
            lista_usuarios.Add(Javier());
            lista_usuarios.Add(Zambri());
            return new RepositorioDeUsuarios_EnMemoria(lista_usuarios);
        }

        public static Funcionalidad FuncionalidadIngresoSacc()
        {
            return new Funcionalidad(1, "ingreso_a_sacc");
        }

        public static Funcionalidad FuncionalidadIngresoModi()
        {
            return new Funcionalidad(2, "ingreso_a_modi");
        }

        public static Funcionalidad FuncionalidadIngresoMenuPrincipal()
        {
            return new Funcionalidad(3, "ingreso_a_menu_principal");
        }

        public static Funcionalidad FuncionalidadIngresoAdministracionDeAreas()
        {
            return new Funcionalidad(4, "ingreso_a_administracion_de_areas");
        }

        public static Funcionalidad FuncionalidadIngresoPantallaLogin()
        {
            return new Funcionalidad(5, "ingreso_a_pantalla_login");
        }

        public static Area AreaDeLegajos()
        {
            return new Area(1, "Legajos");
        }

        public static Area AreaDeContratos()
        {
            return new Area(2, "Contratos");
        }

        //public static Autorizador AutorizadorCon(IRepositorioDePermisosSobreAreas repo)
        //{
        //    return new Autorizador(diccionario_permisos(), menues(), diccionario_areas(), TestObjectsMau.RepositorioDeUsuarios(), TestObjectsMau.RepositorioDePermisosSobreAreas()); 
        //}

        //public static Autorizador AutorizadorCon(IRepositorioDeFuncionalidades repo)
        //{
        //    return new Autorizador(repo, menues(), diccionario_areas(), TestObjectsMau.RepositorioDeUsuarios(), TestObjectsMau.RepositorioDePermisosSobreAreas());
        //}

        public static string URLInicioSacc()
        {
            return @"/WEBRH/SACC/Inicio.aspx";
        }

        public static string URLInicioModi()
        {
            return @"/WEBRH/Modi/Modi.aspx";
        }

        public static string URLInicioAdministracionDeAreas()
        {
            return @"/WEBRH/SeleccionDeArea.aspx";
        }

        public static string URLPantallaLogin()
        {
            return @"/WEBRH/Login.aspx";
        }

        public static string URLMenuPrincipal()
        {
            return @"/WEBRH/MenuPrincipal/Menu.aspx";
        }
    }
}
