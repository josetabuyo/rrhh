using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdministracionDeUsuarios;
using General;

namespace TestAdministracionDeUsuarios
{
    [TestClass]
    public class TestPermisos
    {
        [TestMethod]
        public void jorge_deberia_poder_loguearse_si_ingresa_bien_su_clave()
        {
            Assert.IsTrue(TestObjects.Autorizador().Login("jorgito", "trespuntouno"));
        }

        [TestMethod]
        public void jorge_deberia_tener_permisos_para_ingresar_a_sacc()
        {
            Assert.IsTrue(TestObjects.Autorizador().PuedeAcceder(TestObjects.Jorge(), TestObjects.FuncionalidadIngresoSacc()));
        }

        [TestMethod]
        public void jorge_no_deberia_tener_permisos_para_ingresar_a_modi()
        {
            Assert.IsFalse(TestObjects.Autorizador().PuedeAcceder(TestObjects.Jorge(), TestObjects.FuncionalidadIngresoModi()));
        }

        [TestMethod]
        public void deberia_poder_darle_permisos_a_jorge_para_ingresar_a_modi()
        {
            var autorizador = TestObjects.Autorizador();
            autorizador.ConcederPermisoA(TestObjects.Jorge(), TestObjects.FuncionalidadIngresoModi());
            Assert.IsTrue(autorizador.PuedeAcceder(TestObjects.Jorge(), TestObjects.FuncionalidadIngresoModi()));
        }

        [TestMethod]
        public void javier_no_deberia_tener_permisos_para_ingresar_a_sacc()
        {
            Assert.IsFalse(TestObjects.Autorizador().PuedeAcceder(TestObjects.Javier(), TestObjects.FuncionalidadIngresoModi()));
        }

        [TestMethod]
        public void deberia_poder_darle_permisos_a_javier_para_ingresar_a_sacc()
        {
            var autorizador = TestObjects.Autorizador();
            autorizador.ConcederPermisoA(TestObjects.Javier(), TestObjects.FuncionalidadIngresoSacc());
            Assert.IsTrue(autorizador.PuedeAcceder(TestObjects.Javier(), TestObjects.FuncionalidadIngresoSacc()));
        }


    }
}
