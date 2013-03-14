using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestViaticos
{
    [TestClass]
    public class TestCircuitoDeViatico
    {
        [TestMethod]
        public void el_circuito_deberia_por_default_subir_por_el_organigrama()
        {
            var organigrama_faby_marta = new Organigrama(TestObjects.AreasDeFabiYMarta(), TestObjects.DependenciasEntreFabyYMarta());
            var saltos_preferenciales = new List<List<int>>();

            var circuito_de_viatico = new CircuitoDeAprobacionDeViatico(organigrama_faby_marta, saltos_preferenciales, TestObjects.AreaDeMarta());
            Assert.AreEqual(TestObjects.AreaDeMarta(), circuito_de_viatico.SiguienteAreaDe(TestObjects.AreaDeFabi()));
        }

        [TestMethod]
        public void el_circuito_deberia_por_default_subir_por_el_organigrama_a_menos_que_haya_una_excepcion()
        {
            var organigrama_faby_marta_y_carlos = new Organigrama(TestObjects.AreasDeFabiMartaYCarlos(), TestObjects.DependenciasEntreFabyMartaYCarlos());
            var saltos_preferenciales = new List<List<int>>() { new List<int>() { TestObjects.AreaDeFabi().Id, TestObjects.AreaDeCastagneto().Id }};

            var circuito_de_viatico = new CircuitoDeAprobacionDeViatico(organigrama_faby_marta_y_carlos, saltos_preferenciales, TestObjects.AreaDeMarta());
            Assert.AreEqual(TestObjects.AreaDeCastagneto(), circuito_de_viatico.SiguienteAreaDe(TestObjects.AreaDeFabi()));
        }
    }
}
