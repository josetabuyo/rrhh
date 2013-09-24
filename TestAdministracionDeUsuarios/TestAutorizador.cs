using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdministracionDeUsuarios;

namespace TestAdministracionDeUsuarios
{
    [TestClass]
    public class TestAutorizador
    {
        [TestMethod]
        public void deberia_poder_tener_acceso_a_una_funcionalidad_previamente_cargada_para_un_usuario()
        {
            var autorizador = TestObjects.Autorizador();

            Assert.IsTrue(autorizador.PuedeAcceder(Juan(), TestObjects.FuncionalidadLecturaLegajos()));
            Assert.IsFalse(autorizador.PuedeAcceder(Juan(), TestObjects.FuncionalidadEsctrituraLegajos()));
        }

        [TestMethod]
        public void deberia_poder_agregar_acceso_a_una_funcionalidad_nueva_a_un_usuario()
        {
            var autorizador = TestObjects.Autorizador();
            autorizador.ConcederPermisoA(TestObjects.Juan(), TestObjects.FuncionalidadEsctrituraLegajos());

            Assert.IsTrue(autorizador.PuedeAcceder(Juan(), TestObjects.FuncionalidadLecturaLegajos()));
            Assert.IsTrue(autorizador.PuedeAcceder(Juan(), TestObjects.FuncionalidadEsctrituraLegajos()));
        }

        [TestMethod]
        public void deberia_poder_agregar_una_funcionalidad_a_un_usuario_que_no_tenia_ninguna()
        {
            var autorizador = TestObjects.Autorizador();
            autorizador.ConcederPermisoA(Roberto(), TestObjects.FuncionalidadLecturaLegajos());

            Assert.IsTrue(autorizador.PuedeAcceder(Roberto(), TestObjects.FuncionalidadLecturaLegajos()));
            Assert.IsFalse(autorizador.PuedeAcceder(Roberto(), TestObjects.FuncionalidadEsctrituraLegajos()));
        }

        protected string Juan()
        {
            return TestObjects.Juan();
        }

        protected List<Funcionalidad> SoloFuncionalidadEscrituraLegajos()
        {
            return new List<Funcionalidad> { FuncionalidadEsctrituraLegajos() };
        }

        protected string Roberto()
        {
            return "roberto";
        }

        protected Funcionalidad FuncionalidadEsctrituraLegajos()
        {
            return TestObjects.FuncionalidadEsctrituraLegajos();
        }
    }
}
