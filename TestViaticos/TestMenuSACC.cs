using System;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace General
{
    [TestClass]
    public class TestMenuSACC
    {
        [TestMethod]
        public void el_submenu_parametria_de_sacc_deberia_tener_cinco_elementos()
        {
            var submenu_parametria = new List<ItemDeMenu>() {
                new ItemDeMenu(), new ItemDeMenu(), new ItemDeMenu(), new ItemDeMenu(), new ItemDeMenu()
            };
            Assert.AreEqual(5, submenu_parametria.ToArray().Length);
        }

        [TestMethod]
        public void los_elementos_del_menu_deben_recibir_el_literal_correcto()
        {
               
        }
    }
}
