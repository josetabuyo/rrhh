using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;
using NMock2;
using System.Web.UI.WebControls;
using WebRhUITestNew;

namespace TestViaticos
{
    [TestClass]
    public class TestRepoLazy
    {
        IConexionBD conexion = TestObjects.ConexionMockeada();
        [TestMethod]
        public void deberia_poder_filtrar_un_objeto()
        {
            string criterio = "{Id:1}";
            var una_provincia = new Provincia(1, "buenos aires");
            var una_localidad = new Localidad(2, "curucuzu cuacatiá");
            var un_nivel = new NivelDeIdioma(1, "curucuzu cuacatiá");

            var filtro = new FiltroDeObjetos(criterio);

            Assert.IsTrue(filtro.Evaluar(una_provincia), "Error al filtrar");
            Assert.IsTrue(filtro.Evaluar(un_nivel), "Error al filtrar");
            Assert.IsFalse(filtro.Evaluar(una_localidad), "Error al filtrar");
        }
    }
}
