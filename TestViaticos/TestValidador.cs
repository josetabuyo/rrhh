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

namespace TestViaticos
{

    [TestClass]
    public class TestValidador
    {

        [TestMethod]
        public void deberia_poder_validar_si_un_objeto_es_nulo()
        {
            Area area = null;
            try
            {
                Validador().NoEsNulo(area, "Area");
                Assert.Fail("Deberia lanzarse excepcion de validacion");
            }
            catch (ExcepcionDeValidacion e)
            {
                Assert.AreEqual("Area, no puede ser null", e.Message);
            }
        }

        [TestMethod]
        public void deberia_poder_validar_si_un_objeto_no_es_nulo()
        {
            Area area = TestObjects.AreaDeFabi();
            Validador().NoEsNulo(area, "Area");

            Assert.AreEqual(TestObjects.AreaDeFabi(), area);
        }

        [TestMethod]
        public void deberia_poder_validar_si_un_id_no_es_valido()
        {
            int id = 0;
            try
            {
                Validador().EsValidoComoId(id, "para blah");
                Assert.Fail("Deberia lanzarse excepcion de validacion");
            }
            catch (ExcepcionDeValidacion e)
            {
                Assert.AreEqual("para blah 0 no es valido como id", e.Message);
            }
        }

        [TestMethod]
        public void deberia_poder_validar_si_un_id_es_valido()
        {
            int id = 234;
            Validador().EsValidoComoId(id, "para blah");

            Assert.AreEqual(234, id);
        }


        [TestMethod]
        public void deberia_poder_validar_si_un_objeto_no_esta_en_una_coleccion()
        {
            List<object> una_coleccion = new List<object>();
            try
            {
                Validador().EstaEnLaColeccion(una_coleccion,1 , "Numeros");
                Assert.Fail("Deberia lanzarse excepcion de validacion");
            }
            catch (ExcepcionDeValidacion e)
            {
                Assert.AreEqual("1, no pertenece a la coleccion de Numeros", e.Message);
            }
        }

        [TestMethod]
        public void deberia_poder_validar_si_un_objeto_esta_en_una_coleccion()
        {
            List<object> una_coleccion = new List<object>();
            una_coleccion.Add(1);

            Validador().EstaEnLaColeccion(una_coleccion, 1, "Numeros");

            Assert.IsTrue(una_coleccion.Contains(1));
        }

        private Validador Validador()
        {
            return new Validador();
        }

    }
}
