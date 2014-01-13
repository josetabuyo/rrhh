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
    //[Ignore]
    public class TestLicencias
    {
        private Persona unaPersona;
        private DateTime unaFecha;
        private ConceptoDeLicencia unConcepto;
        private Usuario unUsuario;
        private Auditoria unaAuditoria;
        private RepositorioLicencias repositorioLicencias;
        private RepositorioPersonas repositorioPersonas;
        private Licencia unaLicencia;
        

        #region TestConfiguration


        [TestInitialize]
        public void Setup()
        {


            //repositorioLicencias = TestObjects.RepoLicenciaMockeado();
            //repositorioPersonas = new RepositorioPersonas();
            //unaFecha = new DateTime(2001, 04, 04);
            //unaPersona = new Persona { Documento = 29753914, Area = new Area { Id = 1 } };


            //unConcepto = new ConceptoDeLicencia { Id = 1 };
            //unUsuario = new Usuario { Id = 1 };
            //unaAuditoria = new Auditoria { UsuarioDeCarga = unUsuario };


            //unaLicencia = new Licencia
            //                  {
            //                      Desde = unaFecha,
            //                      Hasta = unaFecha,
            //                      Persona = unaPersona,
            //                      Concepto = unConcepto,
            //                      Auditoria = unaAuditoria
            //                  };

            //repositorioLicencias.Guardar(unaLicencia);
        }

        [TestCleanup]
        public void TearDown()
        {
            //repositorioPersonas.EliminarInasistenciaALaFecha(unaPersona, unaFecha);
        }

        #endregion

        /// <summary>
        /// Este test prueba que no se pueda cargar una solicitud
        /// si se superpone con otra ya cargada
        /// </summary>
        [TestMethod]
        public void TestValidacionSolicitudesSuperpuestas()
        {
            var otraLicencia = new Licencia();
            //var estadoPrevio = repositorioLicencias.Guardar(unaLicencia);
            //Assert.IsNull(estadoPrevio);

            otraLicencia.Desde = unaFecha;
            otraLicencia.Hasta = unaFecha;
            otraLicencia.Persona = unaPersona;
            otraLicencia.Concepto = unConcepto;
            otraLicencia.Auditoria = unaAuditoria;

            var mensajeObtenido = repositorioLicencias.Guardar(otraLicencia);

            const string mensajeEsperado = "Error, ya existe una solicitud cargada en ese periodo.";
            Assert.AreEqual(mensajeObtenido, mensajeEsperado);

            repositorioPersonas.EliminarInasistenciaALaFecha(unaPersona, unaFecha);

        }


        /// <summary>
        /// Este test prueba que no se pueda cargar una licencia si ya 
        /// esta cargada o solicitada para ese periodo
        /// </summary>
        [TestMethod]
        public void TestValidacionLicenciasSuperpuestas()
        {

            var otraLicencia = new Licencia();
            var otraFecha = new DateTime(2001, 04, 04);

            repositorioLicencias.Guardar(unaLicencia);

            otraLicencia.Desde = otraFecha;
            otraLicencia.Hasta = otraFecha;
            otraLicencia.Persona = unaPersona;
            otraLicencia.Concepto = unConcepto;
            otraLicencia.Auditoria = unaAuditoria;
            string mensajeObtenido = repositorioLicencias.Guardar(otraLicencia);
            const string mensajeEsperado = "Error, ya existe una solicitud cargada en ese periodo.";
            Assert.AreEqual(mensajeEsperado, mensajeObtenido);
        }

        /// <summary>
        /// Se testea la solicitud de una licencia.
        /// </summary>
        [TestMethod]
        public void TestSolucitudDeLicencia()
        {
            var otraLicencia = new Licencia();
            var otraFecha = new DateTime(2005, 6, 10);

            otraLicencia.Desde = otraFecha;
            otraLicencia.Hasta = otraFecha;
            otraLicencia.Persona = unaPersona;
            otraLicencia.Concepto = unConcepto;
            otraLicencia.Auditoria = unaAuditoria;

            string mensajeObtenido = repositorioLicencias.Guardar(otraLicencia);
            const string mensajeEsperado = null;
            Assert.IsNull(mensajeEsperado);

            repositorioPersonas.EliminarInasistenciaALaFecha(unaPersona, otraFecha);
        }

        [TestMethod]
        public void deberia_saber_cuantas_vacaciones_permitidas_tiene_agus()
        {
            string source = @"  |NroDocumento	|Apellido       |Nombre                 |Id_Interna     |Dias_Autorizados  |Periodo    |Dias_Tomados	  
                                |29753914  	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |2009       |0                
                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |2010       |0                        
                                |29753914  	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |2011       |0                
                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |25                |2012       |0              ";                    
           
            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var persona = TestObjects.UnaPersona();
           
            CalculadorDeVacaciones calculador = new CalculadorDeVacaciones(new RepositorioLicencias(conexion));
            
            var vacaciones_permitidas_de_agus = new VacacionesPermitidas();
            var periodo = new Periodo(new DateTime(2010,01,01),new DateTime(2010,12,31));
            Assert.AreEqual(4, calculador.CalcularVacacionesPermitidasPara(persona).Count());

        }

        [TestMethod]
        public void deberia_saber_cuantas_vacaciones_permitidas_tiene_agus_para_el_2010()
        {
            string source = @"  |NroDocumento	|Apellido       |Nombre                 |Id_Interna     |Dias_Autorizados  |Periodo    |Dias_Tomados	  
                                |29753914  	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |2009       |0                
                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |2010       |0                        
                                |29753914  	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |2011       |0                
                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |25                |2012       |0              ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var persona = TestObjects.UnaPersona();

            CalculadorDeVacaciones calculador = new CalculadorDeVacaciones(new RepositorioLicencias(conexion));

            var vacaciones_permitidas_de_agus = new VacacionesPermitidas();
            var periodo = new Periodo(new DateTime(2010, 01, 01), new DateTime(2010, 12, 31));
            periodo.anio = 2012;
            Assert.AreEqual(25, calculador.CalcularVacacionesPermitidasParaEn(persona, periodo).Dias);

        }


    }
}
