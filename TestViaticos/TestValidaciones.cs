using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestViaticos
{
    [TestClass]
    public class TestValidaciones
    {

        [TestMethod]
        public void deberia_evaluar_el_bloque_ENTONCES_si_la_condicion_es_valida()
        {
            var objeto_a_validar = 7;
            int objeto_valido_recibido = 0;
            
            var validador = new ValidadorNumerNatural();

            ValidadorNumerNatural a = validador.SiEsValido(objeto_a_validar)
                .Entonces(objeto_valido => { objeto_valido_recibido = objeto_valido; })
                .SiNo(objeto_invalido => { Assert.Fail("El objeto deberia ser valido"); });

            Assert.AreEqual(objeto_a_validar, objeto_valido_recibido);
        }

        [TestMethod]
        public void deberia_evaluar_el_bloque_SiNo_si_la_condicion_es_invalida()
        {
            var objeto_a_validar = -1;
            int objeto_invalido_recibido = 0;

            var validador = new ValidadorNumerNatural();

            ValidadorNumerNatural a = validador.SiEsValido(objeto_a_validar)
                .Entonces(objeto_valido => { Assert.Fail("El objeto deberia ser invalido"); })
                .SiNo(objeto_invalido => { objeto_invalido_recibido = objeto_invalido; });

            Assert.AreEqual(objeto_a_validar, objeto_invalido_recibido);
        }
    }
}
