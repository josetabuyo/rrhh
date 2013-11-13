using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdministracionDeUsuarios;

namespace TestAdministracionDeUsuarios
{
    [TestClass]
    public class TestFuncionalidades
    {
        [TestMethod]
        public void dar_acceso_a_una_funcionalidad_permite_acceso_a_subfuncionalidades()
        {
            var autorizador = TestObjects.Autorizador();

            var funcionalidad_acceso_a_contratos = new Funcionalidad("acceso a contratos");
            var funcionalidad_rescindir_contratos = new Funcionalidad("rescindir contrato");
            funcionalidad_acceso_a_contratos.AgregarFuncionalidad(funcionalidad_rescindir_contratos);

            autorizador.ConcederPermisoA(Juan(), funcionalidad_acceso_a_contratos);

            Assert.IsTrue(autorizador.PuedeAcceder(TestObjects.Juan(), funcionalidad_acceso_a_contratos));
            Assert.IsTrue(autorizador.PuedeAcceder(TestObjects.Juan(), funcionalidad_rescindir_contratos));
        }

        [TestMethod]
        public void deberia_poder_denegar_un_permiso()
        {
            var autorizador = TestObjects.Autorizador();

            var funcionalidad_acceso_a_contratos = new Funcionalidad("acceso a contratos");
            var funcionalidad_rescindir_contratos = new Funcionalidad("rescindir contrato");
            funcionalidad_acceso_a_contratos.AgregarFuncionalidad(funcionalidad_rescindir_contratos);

            autorizador.ConcederPermisoA(Juan(), funcionalidad_acceso_a_contratos);
            autorizador.DenegarPermisoA(Juan(), funcionalidad_rescindir_contratos);

            Assert.IsTrue(autorizador.PuedeAcceder(TestObjects.Juan(), funcionalidad_acceso_a_contratos));
            Assert.IsFalse(autorizador.PuedeAcceder(TestObjects.Juan(), funcionalidad_rescindir_contratos));
        }

        [TestMethod]
        [Ignore]
        public void deberia_lanzar_error_si_el_arbol_de_funcionalidades_tiene_un_loop()
        {
        }

        protected string Juan()
        {
            return TestObjects.Juan();
        }
    }
}
