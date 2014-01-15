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
        private DateTime FechaDesde;
        private DateTime FechaHasta;
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
            FechaDesde = new DateTime(2012, 01, 01);
            FechaHasta = new DateTime(2012, 12, 31);
            //unaPersona = new Persona { Documento = 29753914, Area = new Area { Id = 1 } };


            unConcepto = new ConceptoDeLicencia { Id = 1 };
            //unUsuario = new Usuario { Id = 1 };
            //unaAuditoria = new Auditoria { UsuarioDeCarga = unUsuario };


            unaLicencia = new Licencia
                              {
                                  Desde = FechaDesde,
                                  Hasta = FechaHasta,
                                  //Persona = unaPersona,
                                  Concepto = unConcepto,
                                  //Auditoria = unaAuditoria
                              };

            //repositorioLicencias.Guardar(unaLicencia);
        }

        //[TestCleanup]
        //public void TearDown()
        //{
        //    //repositorioPersonas.EliminarInasistenciaALaFecha(unaPersona, unaFecha);
        //}

        #endregion

        /// <summary>
        /// Este test prueba que no se pueda cargar una solicitud
        /// si se superpone con otra ya cargada
        /// </summary>
        //[TestMethod]
        //public void TestValidacionSolicitudesSuperpuestas()
        //{
        //    //var otraLicencia = new Licencia();
        //    ////var estadoPrevio = repositorioLicencias.Guardar(unaLicencia);
        //    ////Assert.IsNull(estadoPrevio);

        //    //otraLicencia.Desde = FechaDesde;
        //    //otraLicencia.Hasta = FechaHasta;
        //    //otraLicencia.Persona = unaPersona;
        //    //otraLicencia.Concepto = unConcepto;
        //    //otraLicencia.Auditoria = unaAuditoria;

        //    //var mensajeObtenido = repositorioLicencias.Guardar(otraLicencia);

        //    //const string mensajeEsperado = "Error, ya existe una solicitud cargada en ese periodo.";
        //    //Assert.AreEqual(mensajeObtenido, mensajeEsperado);

        //    //repositorioPersonas.EliminarInasistenciaALaFecha(unaPersona, FechaDesde);

        //}


        /// <summary>
        /// Este test prueba que no se pueda cargar una licencia si ya 
        /// esta cargada o solicitada para ese periodo
        /// </summary>
        //[TestMethod]
        //public void TestValidacionLicenciasSuperpuestas()
        //{

        //    var otraLicencia = new Licencia();
        //    var otraFecha = new DateTime(2001, 04, 04);

        //    repositorioLicencias.Guardar(unaLicencia);

        //    otraLicencia.Desde = otraFecha;
        //    otraLicencia.Hasta = otraFecha;
        //    otraLicencia.Persona = unaPersona;
        //    otraLicencia.Concepto = unConcepto;
        //    otraLicencia.Auditoria = unaAuditoria;
        //    string mensajeObtenido = repositorioLicencias.Guardar(otraLicencia);
        //    const string mensajeEsperado = "Error, ya existe una solicitud cargada en ese periodo.";
        //    Assert.AreEqual(mensajeEsperado, mensajeObtenido);
        //}

        /// <summary>
        /// Se testea la solicitud de una licencia.
        /// </summary>
        //[TestMethod]
        //public void TestSolucitudDeLicencia()
        //{
        //    var otraLicencia = new Licencia();
        //    var otraFecha = new DateTime(2005, 6, 10);

        //    otraLicencia.Desde = otraFecha;
        //    otraLicencia.Hasta = otraFecha;
        //    otraLicencia.Persona = unaPersona;
        //    otraLicencia.Concepto = unConcepto;
        //    otraLicencia.Auditoria = unaAuditoria;

        //    string mensajeObtenido = repositorioLicencias.Guardar(otraLicencia);
        //    const string mensajeEsperado = null;
        //    Assert.IsNull(mensajeEsperado);

        //    repositorioPersonas.EliminarInasistenciaALaFecha(unaPersona, otraFecha);
        //}

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
        public void deberia_saber_cuantos_dias_en_total_tiene_agus_permitido()
        {
            IConexionBD conexion = TestObjects.ConexionMockeada();

            var persona = TestObjects.UnaPersona();

            CalculadorDeVacaciones calculador = new CalculadorDeVacaciones(new RepositorioLicencias(conexion));

            Assert.AreEqual(90, calculador.CalcularTotalPermitido(new List<VacacionesPermitidas>() { new VacacionesPermitidas(persona,new Periodo(),90,1) }));


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
            Assert.AreEqual(25, calculador.ObtenerLicenciasPermitidasPara(persona, periodo, licencia).First().Dias);

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


        [TestMethod]
        public void xxxx()
        {

            var permitidas_para_juan = new VacacionesPermitidas(juan, 2013, 20);

            var aprobadas_para_juan = new VacacionesAprobadas(juan, primero_de_enero, cinco_de_enero);

            var pendientes_de_aprobar_a_juan = new VacacionesPendientesDeAprobacion(juan, primero_de_febrero, cinco_de_febrero);

            var calculador_de_vacaciones = new CalculadorDeVacaciones(TestObjects.RepoLicenciaMockeado());

            var dias_restantes_de_juan = calculador_de_vacaciones.DiasRestantes(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);

            Assert.AreEqual(10, dias_restantes_de_juan);
        }


        public object primero_de_febrero { get; set; }

        public object cinco_de_febrero { get; set; }

        public Persona juan { get; set; }

        public Periodo primero_de_enero { get; set; }

        public int cinco_de_enero { get; set; }
    }
}
