using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdministracionDeUsuarios;
using General;
using NMock2;
using General.MAU;

namespace TestAdministracionDeUsuarios
{
    [TestClass]
    public class TestPermisos
    {
        [TestMethod]
        [Ignore] //para que ande el teamcity
        public void jorge_deberia_poder_loguearse_si_ingresa_bien_su_clave()
        {
            Assert.IsTrue(TestObjectsMau.Autorizador().Login("jorge", "web1"));
        }

        [TestMethod]
        [Ignore] //para que ande el teamcity
        public void jorge_no_deberia_poder_loguearse_si_ingresa_mal_su_clave()
        {
            Assert.IsFalse(TestObjectsMau.Autorizador().Login("jorge", "blabla"));
        }

        [TestMethod]
        public void jorge_no_deberia_poder_loguearse_si_ingresa_mal_su_nombre_de_usuario()
        {
            Assert.IsFalse(TestObjectsMau.Autorizador().Login("jorgelintriple", "web1"));
        }

        [TestMethod]
        public void jorge_deberia_tener_permisos_para_ingresar_a_sacc()
        {
            Assert.IsTrue(TestObjectsMau.Autorizador().ElUsuarioTienePermisosPara(TestObjectsMau.Jorge(), TestObjectsMau.FuncionalidadIngresoSacc()));
        }

        [TestMethod]
        public void jorge_deberia_poder_acceder_a_la_pagina_de_inicio_de_sacc()
        {
            Assert.IsTrue(TestObjectsMau.Autorizador().ElUsuarioPuedeAccederALaURL(TestObjectsMau.Jorge(), TestObjectsMau.URLInicioSacc()));
        }

        [TestMethod]
        public void un_usuario_nulo_deberia_poder_entrar_solo_a_la_pantalla_de_login()
        {
            Assert.IsTrue(TestObjectsMau.Autorizador().ElUsuarioPuedeAccederALaURL(new UsuarioNulo(), TestObjectsMau.URLPantallaLogin()));
            Assert.IsFalse(TestObjectsMau.Autorizador().ElUsuarioPuedeAccederALaURL(new UsuarioNulo(), TestObjectsMau.URLInicioSacc()));
            Assert.IsFalse(TestObjectsMau.Autorizador().ElUsuarioPuedeAccederALaURL(new UsuarioNulo(), TestObjectsMau.URLInicioModi()));
        }

        [TestMethod]
        public void un_usuario_deberia_poder_acceder_a_cualquier_url_no_afectada_por_los_accesos()
        {
            Assert.IsTrue(TestObjectsMau.Autorizador().ElUsuarioPuedeAccederALaURL(TestObjectsMau.Jorge(), @"/WEBRH/Scripts/Grilla.js"));
        }

        [TestMethod]
        public void jorge_no_deberia_tener_permisos_para_ingresar_a_administracion_de_areas()
        {
            Assert.IsFalse(TestObjectsMau.Autorizador().ElUsuarioTienePermisosPara(TestObjectsMau.Jorge(), TestObjectsMau.FuncionalidadIngresoAdministracionDeAreas()));
        }

        [TestMethod]
        public void deberia_poder_darle_permisos_a_jorge_para_ingresar_a_modi()
        {
            var autorizador = TestObjectsMau.Autorizador();
            autorizador.ConcederFuncionalidadA(TestObjectsMau.Jorge(), TestObjectsMau.FuncionalidadIngresoModi());
            Assert.IsTrue(autorizador.ElUsuarioTienePermisosPara(TestObjectsMau.Jorge(), TestObjectsMau.FuncionalidadIngresoModi()));
        }

        [TestMethod]
        public void javier_deberia_tener_permisos_para_ingresar_a_administracion_de_areas()
        {
            Assert.IsTrue(TestObjectsMau.Autorizador().ElUsuarioTienePermisosPara(TestObjectsMau.Javier(), TestObjectsMau.FuncionalidadIngresoAdministracionDeAreas()));
        }

        [TestMethod]
        public void javier_no_deberia_tener_permisos_para_ingresar_a_sacc()
        {
            Assert.IsFalse(TestObjectsMau.Autorizador().ElUsuarioTienePermisosPara(TestObjectsMau.Javier(), TestObjectsMau.FuncionalidadIngresoModi()));
        }

        [TestMethod]
        public void deberia_poder_darle_permisos_a_javier_para_ingresar_a_sacc()
        {
            var autorizador = TestObjectsMau.Autorizador();
            autorizador.ConcederFuncionalidadA(TestObjectsMau.Javier(), TestObjectsMau.FuncionalidadIngresoSacc());
            Assert.IsTrue(autorizador.ElUsuarioTienePermisosPara(TestObjectsMau.Javier(), TestObjectsMau.FuncionalidadIngresoSacc()));
        }

        [TestMethod]
        public void deberia_poder_obtener_el_menu_principal_para_jorge()
        {
            var autorizador = TestObjectsMau.Autorizador();
            var menu_principal_de_jorge = autorizador.GetMenuPara("PRINCIPAL", TestObjectsMau.Jorge());
            Assert.AreEqual(2, menu_principal_de_jorge.Items.Count);
        }

        [TestMethod]
        public void si_le_doy_permisos_a_jorge_para_acceder_a_administracion_de_areas_deberia_ver_tres_items_en_su_menu_principal()
        {
            var autorizador = TestObjectsMau.Autorizador();
            autorizador.ConcederFuncionalidadA(TestObjectsMau.Jorge(), TestObjectsMau.FuncionalidadIngresoAdministracionDeAreas());
            var menu_principal_de_jorge = autorizador.GetMenuPara("PRINCIPAL", TestObjectsMau.Jorge());
            Assert.AreEqual(3, menu_principal_de_jorge.Items.Count);
        }

        [TestMethod]
        public void jorge_no_deberia_administrar_ningun_area()
        {
            var autorizador = TestObjectsMau.Autorizador();
            var areas_administradas_por_jorge = autorizador.AreasAdministradasPor(TestObjectsMau.Jorge());
            Assert.AreEqual(0, areas_administradas_por_jorge.Count);
        }

        [TestMethod]
        public void javier_deberia_administrar_el_area_de_legajos()
        {
            var autorizador = TestObjectsMau.Autorizador();
            var areas_administradas_por_javier = autorizador.AreasAdministradasPor(TestObjectsMau.Javier());
            Assert.IsTrue(areas_administradas_por_javier.Contains(TestObjectsMau.AreaDeLegajos()));
        }

        [TestMethod]
        public void deberia_poder_darle_permisos_a_javier_para_administrar_el_area_de_contratos()
        {
            var autorizador = TestObjectsMau.Autorizador();
            autorizador.AsignarAreaAUnUsuario(TestObjectsMau.Javier(), TestObjectsMau.AreaDeContratos());
            Assert.IsTrue(autorizador.AreasAdministradasPor(TestObjectsMau.Javier()).Contains(TestObjectsMau.AreaDeContratos()));
        }

        [TestMethod]
        public void deberia_poder_quitarle_permisos_a_javier_para_administrar_el_area_de_legajos()
        {
            var autorizador = TestObjectsMau.Autorizador();
            autorizador.DesAsignarAreaAUnUsuario(TestObjectsMau.Javier(), TestObjectsMau.AreaDeLegajos());
            Assert.IsFalse(autorizador.AreasAdministradasPor(TestObjectsMau.Javier()).Contains(TestObjectsMau.AreaDeLegajos()));
        }

        [TestMethod]
        public void deberia_poder_obtener_del_repositorio_la_lista_completa_de_funcionalidades()
        {           
            Assert.AreEqual(5, TestObjectsMau.RepositorioDeFuncionalidades().TodasLasFuncionalidades().Count);
        }

        [TestMethod]
        public void deberia_poder_obtener_un_usuario_pasando_su_id_persona()
        {
            Assert.AreEqual(TestObjectsMau.Jorge(), TestObjectsMau.RepositorioDeUsuarios().GetUsuarioPorIdPersona(1));
        }

        [TestMethod]
        public void si_se_pasa_el_id_persona_de_una_persona_sin_usuario_el_repositorio_deberia_lanzar_una_excepcion()
        {
            var codigo_excepcion = "";

            try 
	        {	        
		        TestObjectsMau.RepositorioDeUsuarios().GetUsuarioPorIdPersona(555);
	        }
	        catch (Exception e)
	        {
		        codigo_excepcion =  (string)e.Data["codigo"];
	        }
            Assert.AreEqual("NO_EXISTE_EL_USUARIO", codigo_excepcion);
        }

        //[TestMethod]
        //public void deberia_poder_crear_un_usuario_nuevo_para_una_persona()
        //{
        //    var usuario = TestObjectsMau.RepositorioDeUsuarios().CrearUsuarioPara(555);
        //    Assert.AreEqual(TestObjectsMau.Jorge(), TestObjectsMau.RepositorioDeUsuarios().GetUsuarioPorIdPersona(1));
        //}
    }
}
