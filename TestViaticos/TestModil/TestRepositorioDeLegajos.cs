using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;
using NDbUnit.Core;
using NDbUnit.Core.SqlClient;
using NMock2;
using TestViaticos.TestModil;

namespace TestViaticos
{

    [TestClass]
    public class TestRepositorioDeLegajos
    {

        [TestInitialize]
        public void Setup()
        {
        }
        
        [TestMethod]
        public void deberia_poder_obtener_un_legajo_pasando_su_numero()
        {
            var un_repo = new RepositorioDeLegajos();
            LegajoModil un_legajo = un_repo.getLegajo(123);
            Assert.AreEqual(123, un_legajo.numero);
        }

        [TestMethod]
        public void si_el_legajo_que_busco_no_existe_deberia_tirar_una_excepcion_acorde()
        {
            var tiro_excepcion = false;
            var un_repo = new RepositorioDeLegajos();
            try
            {
                LegajoModil un_legajo = un_repo.getLegajo(234);
            }
            catch (ExcepcionDeLegajoInexistente e)
            {
                tiro_excepcion = true;
            }
            Assert.IsTrue(tiro_excepcion);
        }
    }
}
