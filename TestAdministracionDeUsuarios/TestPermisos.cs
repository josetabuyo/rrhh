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
        public void jorge_deberia_tener_permisos_para_ignresar_a_sacc()
        {
            Assert.IsTrue(TestObjects.Autorizador().PuedeAcceder(TestObjects.Jorge(), TestObjects.FuncionalidadIngresoSacc()));
        }

    }
}
