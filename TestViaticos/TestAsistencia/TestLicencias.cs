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
   // [Ignore]
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
        private IConexionBD conexion;
        private string source;
        private Licencia una_licencia_del_04_04_2001;
        List<Licencia> lista_licencias;

        #region TestConfiguration


        [TestInitialize]
        public void Setup()
        {

            una_licencia_del_04_04_2001 = TestObjects.UnaLicencia();

            lista_licencias = new List<Licencia>() { una_licencia_del_04_04_2001 };
            
            //conexion = TestObjects.ConexionMockeada();

            //repositorioLicencias = new RepositorioLicencias(conexion);
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

           // source = @"  |id     	    |id_interna     |concepto   |desde                      |hasta                      |usuario    |fecha_solicitud            |id_area    |baja
            //             |1	            |29753914       |1          |2001-04-04 00:00:00.000    |2001-04-04 00:00:00.000    |1          |2001-04-04 00:00:00.000    |1          |0       ";

        }

        [TestCleanup]
        public void TearDown()
        {
            repositorioPersonas.EliminarInasistenciaALaFecha(unaPersona, unaFecha);
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


            //conexion = TestObjects.ConexionMockeada();
            //var resultado_sp = TablaDeDatos.From(source);

           // Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));



            var mensajeObtenido = repositorioLicencias.Guardar(otraLicencia);

            const string mensajeEsperado = "Error, ya existe una solicitud cargada en ese periodo.";
            Assert.AreEqual(mensajeObtenido, mensajeEsperado);

            //Assert.IsTrue(lista

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
    }
}
