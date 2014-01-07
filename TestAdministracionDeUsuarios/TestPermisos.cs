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
        public void jorge_deberia_poder_loguearse_si_ingresa_bien_su_clave()
        {
            Assert.IsTrue(TestObjectsMau.Autorizador().Login("jorge", "web1"));
        }

        [TestMethod]
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
        public void jorge_no_deberia_tener_permisos_para_ingresar_a_administracion_de_areas()
        {
            Assert.IsFalse(TestObjectsMau.Autorizador().ElUsuarioTienePermisosPara(TestObjectsMau.Jorge(), TestObjectsMau.FuncionalidadIngresoAdministracionDeAreas()));
        }

        [TestMethod]
        public void deberia_poder_darle_permisos_a_jorge_para_ingresar_a_modi()
        {
            var autorizador = TestObjectsMau.Autorizador();
            autorizador.ConcederPermisoA(TestObjectsMau.Jorge(), TestObjectsMau.FuncionalidadIngresoModi());
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
            autorizador.ConcederPermisoA(TestObjectsMau.Javier(), TestObjectsMau.FuncionalidadIngresoSacc());
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
            autorizador.ConcederPermisoA(TestObjectsMau.Jorge(), TestObjectsMau.FuncionalidadIngresoAdministracionDeAreas());
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
        public void al_pedirle_al_autorizador_las_areas_administradas_por_javier_el_autorizador_pide_a_un_repositorio_los_datos()
        {
            var mocks = new Mockery();
            var repo = mocks.NewMock<IRepositorioDePermisosSobreAreas>();
            var autorizador = TestObjectsMau.Autorizador();

            Expect.AtLeastOnce.On(repo).Method("AreasAdministradasPor").WithAnyArguments();

            autorizador.AreasAdministradasPor(TestObjectsMau.Javier());
        }

    }
}
