using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General;
using General.Repositorios;
using NMock2;

namespace TestViaticos
{

            

    [TestClass]
    public class TestRepositorioLicencias
    {
        protected Licencia unaLicencia;
        protected DateTime FechaDesde;
        protected DateTime FechaHasta;
        protected ConceptoDeLicencia unConcepto;

        [TestInitialize]
        public void Setup()
        {
            FechaDesde = new DateTime(2012, 01, 01);
            FechaHasta = new DateTime(2012, 12, 31);

            unConcepto = new ConceptoDeLicencia { Id = 1 };


            unaLicencia = new Licencia
            {
                Desde = FechaDesde,
                Hasta = FechaHasta,

                Concepto = unConcepto,

            };
        }

        [TestMethod]
        public void deberia_saber_cuantas_vacaciones_permitidas_tiene_agus()
        {
            string source = @"  |NroDocumento	|Apellido       |Nombre                 |Id_Interna     |Dias_Autorizados  |Id_Concepto_Licencia |Periodo    |Dias_Tomados	  
                                |29753914  	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |1                    |2009       |0                
                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |1                    |2010       |0                        
                                |29753914  	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |1                    |2011       |0                
                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |30                |1                    |2012       |0             ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var persona = TestObjects.UnaPersona();

            CalculadorDeVacaciones calculador = new CalculadorDeVacaciones(new RepositorioLicencias(conexion));

            //var vacaciones_permitidas_de_agus = new VacacionesPermitidas();
            //var periodo = new Periodo(new DateTime(2010,01,01),new DateTime(2010,12,31));
            Assert.AreEqual(4, calculador.ObtenerLicenciasPermitidasPara(persona).Count());
            //Assert.AreEqual(90, calculador.ObtenerLicenciasPermitidasPara(persona, null, null).Select(v => v.Dias).Sum());

        }


        [TestMethod]
        public void deberia_saber_cuantas_vacaciones_permitidas_tiene_agus_para_el_2012_para_el_concepto_1()
        {
            string source = @"  |NroDocumento	|Apellido       |Nombre                 |Id_Interna     |Dias_Autorizados |Id_Concepto_Licencia  |Periodo    |Dias_Tomados	                  
                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |25               |1                     |2012       |0              ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var persona = TestObjects.UnaPersona();

            CalculadorDeVacaciones calculador = new CalculadorDeVacaciones(new RepositorioLicencias(conexion));
            Licencia licencia = unaLicencia;

            //var vacaciones_permitidas_de_agus = new VacacionesPermitidas();
            var periodo = new Periodo(new DateTime(2010, 01, 01), new DateTime(2010, 12, 31));
            periodo.anio = 2012;
            Assert.AreEqual(25, calculador.ObtenerLicenciasPermitidasPara(persona, periodo, licencia).First().CantidadDeDias());

        }


        //        [TestMethod]
        //        public void Si_el_concepto_de_vacaciones_es_1_deberia_saber_cuantas_vacaciones_permitidas_tiene_agus()
        //        {
        //            string source = @"  |NroDocumento	|Apellido       |Nombre                 |Id_Interna     |Dias_Autorizados  |Id_Concepto_Licencia |Periodo    |Dias_Tomados	  
        //                                |29753914  	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |1                    |2009       |0                
        //                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |2                    |2010       |0                        
        //                                |29753914  	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |3                    |2011       |0                
        //                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |25                |1                    |2012       |0              ";

        //            IConexionBD conexion = TestObjects.ConexionMockeada();
        //            var resultado_sp = TablaDeDatos.From(source);

        //            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

        //            var persona = TestObjects.UnaPersona();

        //            CalculadorDeVacaciones calculador = new CalculadorDeVacaciones(new RepositorioLicencias(conexion));

        //            var lista_de_licencias_de_agus = calculador.ObtenerVacacionesPermitidasPara(persona, null,null);

        //            var vacaciones = new VacacionesPermitidas();

        //            int total = vacaciones.CalcularTotalPermitido(lista_de_licencias_de_agus);

        //            Assert.AreEqual(45, total);

        //        }

        //        [TestMethod]
        //        public void deberia_saber_cuantas_vacaciones_aprobadas_tiene_agus()
        //        {
        //            string source = @"  |NroDocumento	|Apellido       |Nombre                 |Id_Interna     |Dias_Autorizados |Id_Concepto_Licencia  |Periodo    |Dias_Tomados	                  
        //                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |25               |1                     |2012       |0              ";

        //            IConexionBD conexion = TestObjects.ConexionMockeada();
        //            var resultado_sp = TablaDeDatos.From(source);

        //            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

        //            var persona = TestObjects.UnaPersona();

        //            CalculadorDeVacaciones calculador = new CalculadorDeVacaciones(new RepositorioLicencias(conexion));
        //            Licencia licencia = unaLicencia;

        //            //var vacaciones_permitidas_de_agus = new VacacionesPermitidas();
        //            var periodo = new Periodo(new DateTime(2010, 01, 01), new DateTime(2010, 12, 31));
        //            periodo.anio = 2012;
        //            Assert.AreEqual(5, calculador.ObtenerLicenciasAprobadasPara(persona, periodo, licencia));

        //        }
    }
}
