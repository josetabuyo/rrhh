using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using General;

namespace General.Test
{
    [TestFixture]
    public class TestCalculoDeViaticos
    {

        /// <summary>
        /// El tipo de contrato es contrato 1184 y cobra menos de 1920,
        /// con lo que deberia
        /// entrar en el caso del viático diario de $84
        /// </summary>
        [Test]
        public void CalcularViaticoPara1184QueCobra1910()
        {
            ModalidadDeContratacion contratacion = new ModalidadDeContratacion1184();
            ((ModalidadDeContratacion1184)contratacion).Retribucion = 1910;
            Persona unaPersona = new Persona { Documento = 29753914, ModalidadDeContratacion = contratacion};
            CalculadorDeViaticos unCalculador = new CalculadorDeViaticos();
            Zona unaZona = new Zona { Id = 3 };
            float MontoEsperado = 84;
            float MontoCalculado = unCalculador.CalculaleLosViaticosA(unaPersona, unaZona);
            Assert.AreEqual(MontoEsperado, MontoCalculado);
        }

        /// <summary>
        /// El tipo de contrato es contrato 1184 y cobra entre 1921 y 2919,
        /// con lo que deberia
        /// entrar en el caso del viático diario de $105
        /// </summary>
        [Test]
        public void CalcularViaticoPara1184QueCobra2000()
        {
            ModalidadDeContratacion contratacion = new ModalidadDeContratacion1184();
            ((ModalidadDeContratacion1184)contratacion).Retribucion = 2000;
            Persona unaPersona = new Persona { Documento = 29753914, ModalidadDeContratacion = contratacion };
            CalculadorDeViaticos unCalculador = new CalculadorDeViaticos();
            Zona unaZona = new Zona { Id = 3 };
            float MontoEsperado = 105;
            float MontoCalculado = unCalculador.CalculaleLosViaticosA(unaPersona, unaZona);
            Assert.AreEqual(MontoEsperado, MontoCalculado);
        }

        /// <summary>
        /// El tipo de contrato es contrato 1184 y cobra más de 2920,
        /// con lo que deberia
        /// entrar en el caso del viático diario de $126
        /// </summary>
        [Test]
        public void CalcularViaticoPara1184QueCobra3100()
        {
            ModalidadDeContratacion contratacion = new ModalidadDeContratacion1184();
            ((ModalidadDeContratacion1184)contratacion).Retribucion = 3100;
            Persona unaPersona = new Persona { Documento = 29753914, ModalidadDeContratacion = contratacion };
            CalculadorDeViaticos unCalculador = new CalculadorDeViaticos();
            Zona unaZona = new Zona { Id = 3 };
            float MontoEsperado = 126;
            float MontoCalculado = unCalculador.CalculaleLosViaticosA(unaPersona, unaZona);
            Assert.AreEqual(MontoEsperado, MontoCalculado);
        }
        
        /// <summary>
        /// El tipo de contrato no es contrato 1184 y es de la zona Metropolitana, 
        /// y es Secretario (W3) con lo que deberia entrar en el caso del 
        /// viático diario de $182
        /// </summary>
        [Test]
        public void CalcularViaticoParaNivelWGrado2EnCuyo()
        {
            Persona unaPersona = new Persona { Documento = 29753914, ModalidadDeContratacion = new ModalidadDeContratacionNivelPolitico() };
            ((ModalidadDeContratacionNivelPolitico)unaPersona.ModalidadDeContratacion).Nivel = "W";
            ((ModalidadDeContratacionNivelPolitico)unaPersona.ModalidadDeContratacion).Grado = 3;
            CalculadorDeViaticos unCalculador = new CalculadorDeViaticos();
            Zona unaZona = new Zona { Nombre = "METROPOLITANA" };
            float MontoEsperado = 182;
            float MontoCalculado = unCalculador.CalculaleLosViaticosA(unaPersona, unaZona);
            Assert.AreEqual(MontoEsperado, MontoCalculado);
        }

        /// <summary>
        /// El tipo de contrato es FuncionEjecutiva y es de la zona Metropolitana, 
        /// viático diario de $188
        /// </summary>
        [Test]
        public void CalcularViaticoParaFuncionEjecutivaEnZonaMetropolitana()
        {
            Persona unaPersona = new Persona { Documento = 29753914, ModalidadDeContratacion = new ModalidadDeContratacionFuncionEjecutiva() };
            CalculadorDeViaticos unCalculador = new CalculadorDeViaticos();
            Zona unaZona = new Zona { Nombre = "METROPOLITANA" };
            float MontoEsperado = 188.6F;
            float MontoCalculado = unCalculador.CalculaleLosViaticosA(unaPersona, unaZona);
            Assert.AreEqual(MontoEsperado, MontoCalculado);
        }

        /// <summary>
        /// El tipo de contrato es "Normal" y es de la zona Metropolitana, 
        /// viático diario de $287
        /// </summary>
        [Test]
        public void CalcularViaticoParaContratacionNormalEnZonaSur()
        {
            Persona unaPersona = new Persona { Documento = 29753914, ModalidadDeContratacion = new ModalidadDeContratacionNormal() };
            CalculadorDeViaticos unCalculador = new CalculadorDeViaticos();
            Zona unaZona = new Zona { Nombre = "SUR" };
            float MontoEsperado = 287F;
            float MontoCalculado = unCalculador.CalculaleLosViaticosA(unaPersona, unaZona);
            Assert.AreEqual(MontoEsperado, MontoCalculado);
        }
    }
}
