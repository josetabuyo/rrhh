using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using General.Repositorios;

namespace Tests
{
    [TestClass]
    public class CodigoTareaTest
    {
        [TestMethod]
        public void dado_a_quiero_b()
        {
            var etiquetador = new Etiquetador("A");
            var codigo_obtenido = etiquetador.Siguiente();

            Assert.AreEqual("B", codigo_obtenido);
        }

        [TestMethod]
        public void dado_b_quiero_c()
        {
            var etiquetador = new Etiquetador("B");
            var codigo_obtenido = etiquetador.Siguiente();

            Assert.AreEqual("C", codigo_obtenido);
        }

        [TestMethod]
        public void dado_1_quiero_2()
        {
            var etiquetador = new Etiquetador("1");
            var codigo_obtenido = etiquetador.Siguiente();

            Assert.AreEqual("2", codigo_obtenido);
        }

        [TestMethod]
        public void dado_az_quiero_ba()
        {
            var etiquetador = new Etiquetador("AZ");
            var codigo_obtenido = etiquetador.Siguiente();

            Assert.AreEqual("BA", codigo_obtenido);
        }

        [TestMethod]
        public void dado_a9_quiero_b0()
        {
            var etiquetador = new Etiquetador("A9");
            var codigo_obtenido = etiquetador.Siguiente();

            Assert.AreEqual("B0", codigo_obtenido);
        }

        [TestMethod]
        public void dado_aazz_debe_ser_abaa()
        {
            var etiquetador = new Etiquetador("AAZZ");
            var codigo_obtenido = etiquetador.Siguiente();

            Assert.AreEqual("ABAA", codigo_obtenido);
        }

        [TestMethod]
        public void dado_aaa999_debe_ser_aab000()
        {
            var etiquetador = new Etiquetador("AAA999");
            var codigo_obtenido = etiquetador.Siguiente();

            Assert.AreEqual("AAB000", codigo_obtenido);
        }

        [TestMethod]
        public void no_deberia_permitir_pasarse_de_zzz999()
        {
            var etiquetador = new Etiquetador("ZZZ999");
            var codigo_obtenido = string.Empty;

            try
            {
                codigo_obtenido = etiquetador.Siguiente();
                Assert.Fail("No deberia poder obtener un codigo sobrepasado");
            }
            catch (CodigoDeTareaAgotadoException e)
            {
                Assert.AreEqual(String.Empty, codigo_obtenido);
                Assert.AreEqual("No se puede generar un código mas grande que ZZZ999", e.Message);
            }
        }

        [TestMethod]
        public void no_deberia_permitir_pasarse_de_z()
        {
            var etiquetador = new Etiquetador("Z");
            var codigo_obtenido = string.Empty;

            try
            {
                codigo_obtenido = etiquetador.Siguiente();
                Assert.Fail("No deberia poder obtener un codigo sobrepasado");
            }
            catch (CodigoDeTareaAgotadoException e)
            {
                Assert.AreEqual(String.Empty, codigo_obtenido);
                Assert.AreEqual("No se puede generar un código mas grande que Z", e.Message);

            }
        }

        [TestMethod]
        public void no_deberia_permitir_pasarse_de_9()
        {
            var etiquetador = new Etiquetador("9");
            var codigo_obtenido = string.Empty;

            try
            {
                codigo_obtenido = etiquetador.Siguiente();
                Assert.Fail("No deberia poder obtener un codigo sobrepasado");
            }
            catch (CodigoDeTareaAgotadoException e)
            {
                Assert.AreEqual(String.Empty, codigo_obtenido);
                Assert.AreEqual("No se puede generar un código mas grande que 9", e.Message);

            }
        }

        /// <summary>
        /// TODO: Ignorado, esta en desarrollo, terminarlo.
        /// </summary>
        //[TestMethod]
        //[Ignore]
        //public void deberia_poder_guardar_un_ticket()
        //{
        //    RepositorioDeTicket repo = new RepositorioDeTicket(); 
        //    var resultado = repo.GuardarTicket("un ticket");
        //    Assert.AreNotEqual(string.Empty, resultado);
        //}
    }
}
