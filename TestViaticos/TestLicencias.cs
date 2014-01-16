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

            Assert.AreEqual(90, calculador.CalcularTotalPermitido(new List<VacacionesPermitidas>() { new VacacionesPermitidas(persona,2012,90,1) }));


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


        [TestMethod]
        public void calcula_el_saldo_de_10_dias_pendientes_para_juan()
        {
            var permitidas_para_juan = new VacacionesPermitidas(juan, 2013, 20);
            var aprobadas_para_juan = new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero());
            var pendientes_de_aprobar_a_juan = new VacacionesPendientesDeAprobacion(juan, primero_de_febrero(), cinco_de_febrero());
            

            var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);

            Assert.AreEqual(10, dias_restantes_de_juan);
        }


        [TestMethod]
        public void calcula_el_saldo_de_20_dias_pendientes_para_juan()
        {
            var permitidas_para_juan = new VacacionesPermitidas(juan, 2013, 30);
            var aprobadas_para_juan = new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero());
            var pendientes_de_aprobar_a_juan = new VacacionesPendientesDeAprobacion(juan, primero_de_febrero(), cinco_de_febrero());
            

            var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);

            Assert.AreEqual(20, dias_restantes_de_juan);
        }


        [TestMethod]
        public void calcula_el_saldo_de_40_dias_permitidos_para_juan_para_2_anios()
        {    
            var permitidas_para_juan = new List<VacacionesPermitidas>(){new VacacionesPermitidas(juan, 2013, 20), new VacacionesPermitidas(juan, 2012, 20)}; 

            var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, new List<VacacionesAprobadas>(), new List<VacacionesPendientesDeAprobacion>());

            Assert.AreEqual(40, dias_restantes_de_juan);
        }

        [TestMethod]
        public void calcula_el_saldo_de_30_dias_permitidas_para_juan_para_2_anios()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2013, 10), new VacacionesPermitidas(juan, 2012, 20) };

            var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, new List<VacacionesAprobadas>(), new List<VacacionesPendientesDeAprobacion>());

            Assert.AreEqual(30, dias_restantes_de_juan);
        }

        [TestMethod]
        public void calcula_el_saldo_de_25_dias_permitidas_para_juan_para_2_anios()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2013, 10), new VacacionesPermitidas(juan, 2012, 20) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero()) };
            var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, aprobadas_para_juan, new List<VacacionesPendientesDeAprobacion>());

            Assert.AreEqual(25, dias_restantes_de_juan);
        }

        [TestMethod]
        public void calcula_el_saldo_de_20_dias_permitidas_y_aprobadas_para_juan_para_2_anios()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2013, 10), new VacacionesPermitidas(juan, 2012, 20) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero()), new VacacionesAprobadas(juan, primero_de_febrero(), cinco_de_febrero()) };
            var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, aprobadas_para_juan, new List<VacacionesPendientesDeAprobacion>());

            Assert.AreEqual(20, dias_restantes_de_juan);
        }

        [TestMethod]
        public void calcula_el_saldo_de_20_dias_permitidas_pendientes_para_juan_para_2_anios()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2013, 10), new VacacionesPermitidas(juan, 2012, 20) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>() { new VacacionesPendientesDeAprobacion(juan, primero_de_enero(), cinco_de_enero()), new VacacionesPendientesDeAprobacion(juan, primero_de_febrero(), cinco_de_febrero()) };
            var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, new List<VacacionesAprobadas>(), pendientes_de_aprobar_a_juan);

            Assert.AreEqual(20, dias_restantes_de_juan);
        }

        [TestMethod]
        public void calcula_el_saldo_de_20_dias_permitidas__aprobadas_pendientes_para_juan_para_2_anios()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2013, 10), new VacacionesPermitidas(juan, 2012, 20) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>() { new VacacionesPendientesDeAprobacion(juan, primero_de_febrero(), cinco_de_febrero()) };
            var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);

            Assert.AreEqual(20, dias_restantes_de_juan);
        }

        [TestMethod]
        public void juan_deberia_poder_solicitar_5_dias_para_2001()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2001, 5) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>();
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);
            var vacaciones_solicitables = listado_solicitables.First();

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2001, vacaciones_solicitables.Periodo());
            Assert.AreEqual(5, vacaciones_solicitables.CantidadDeDias());

        }


        [TestMethod]
        public void juan_deberia_poder_solicitar_10_dias_para_2002()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2002, 10) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>();
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);
            var vacaciones_solicitables = listado_solicitables.First();

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2002, vacaciones_solicitables.Periodo());
            Assert.AreEqual(10, vacaciones_solicitables.CantidadDeDias());

        }


        [TestMethod]
        public void juan_deberia_poder_solicitar_5_dias_para_2001_y_10_dias_para_2002()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2001, 5), new VacacionesPermitidas(juan, 2002, 10) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>();
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);
            var vacaciones_solicitables_2001 = listado_solicitables.First();
            var vacaciones_solicitables_2002 = listado_solicitables.Last();

            Assert.AreEqual(2, listado_solicitables.Count());
            Assert.AreEqual(2001, vacaciones_solicitables_2001.Periodo());
            Assert.AreEqual(5, vacaciones_solicitables_2001.CantidadDeDias());
            Assert.AreEqual(2002, vacaciones_solicitables_2002.Periodo());
            Assert.AreEqual(10, vacaciones_solicitables_2002.CantidadDeDias());

        }

        [TestMethod]
        public void juan_deberia_poder_solicitar_7_dias_para_2002()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2002, 12) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);
            var vacaciones_solicitables = listado_solicitables.First();

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2002, vacaciones_solicitables.Periodo());
            Assert.AreEqual(7, vacaciones_solicitables.CantidadDeDias());

        }

        [TestMethod]
        public void juan_deberia_poder_solicitar_2_dias_para_2002()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2002, 12) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero()), new VacacionesAprobadas(juan, primero_de_febrero(), cinco_de_febrero()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);
            var vacaciones_solicitables = listado_solicitables.First();

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2002, vacaciones_solicitables.Periodo());
            Assert.AreEqual(2, vacaciones_solicitables.CantidadDeDias());

        }


        [TestMethod]
        public void juan_deberia_poder_solicitar_7_dias_para_2002_y_20_para_2003()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2002, 12), new VacacionesPermitidas(juan, 2003, 20) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);
          
            var vacaciones_solicitables_2001 = listado_solicitables.First();
            var vacaciones_solicitables_2002 = listado_solicitables.Last();

            Assert.AreEqual(2, listado_solicitables.Count());
            Assert.AreEqual(2002, vacaciones_solicitables_2001.Periodo());
            Assert.AreEqual(7, vacaciones_solicitables_2001.CantidadDeDias());
            Assert.AreEqual(2003, vacaciones_solicitables_2002.Periodo());
            Assert.AreEqual(20, vacaciones_solicitables_2002.CantidadDeDias());

        }

        [TestMethod]
        public void juan_deberia_poder_solicitar_0_dias_para_2002_y_17_para_2003()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2002, 12), new VacacionesPermitidas(juan, 2003, 20) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero()), new VacacionesAprobadas(juan, primero_de_marzo(), diez_de_marzo()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);

            var vacaciones_solicitables_2001 = listado_solicitables.First();
            var vacaciones_solicitables_2002 = listado_solicitables.Last();

            Assert.AreEqual(2, listado_solicitables.Count());
            Assert.AreEqual(2002, vacaciones_solicitables_2001.Periodo());
            Assert.AreEqual(0, vacaciones_solicitables_2001.CantidadDeDias());
            Assert.AreEqual(2003, vacaciones_solicitables_2002.Periodo());
            Assert.AreEqual(17, vacaciones_solicitables_2002.CantidadDeDias());

        }

        [TestMethod]
        public void juan_deberia_poder_solicitar_0_dias_para_2002_y_0_para_2003_y_10_para_2004()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2002, 12), new VacacionesPermitidas(juan, 2003, 20), new VacacionesPermitidas(juan, 2004, 20) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero()), new VacacionesAprobadas(juan, primero_de_marzo(), diez_de_marzo()), new VacacionesAprobadas(juan, primero_de_abril(), veinte_de_abril()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);

            var vacaciones_solicitables_2002 = listado_solicitables[0];
            var vacaciones_solicitables_2003 = listado_solicitables[1];
            var vacaciones_solicitables_2004 = listado_solicitables[2];

            Assert.AreEqual(3, listado_solicitables.Count());
            Assert.AreEqual(2002, vacaciones_solicitables_2002.Periodo());
            Assert.AreEqual(0, vacaciones_solicitables_2002.CantidadDeDias());
            Assert.AreEqual(2003, vacaciones_solicitables_2003.Periodo());
            Assert.AreEqual(0, vacaciones_solicitables_2003.CantidadDeDias());
            Assert.AreEqual(2004, vacaciones_solicitables_2004.Periodo());
            Assert.AreEqual(17, vacaciones_solicitables_2004.CantidadDeDias());

        }

        [TestMethod]
        public void juan_deberia_poder_solicitar_0_dias_para_2002_y_12_para_2003_y_tener_pendiente_5()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { new VacacionesPermitidas(juan, 2002, 12), new VacacionesPermitidas(juan, 2003, 20) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero()), new VacacionesAprobadas(juan, primero_de_marzo(), diez_de_marzo())};
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>() { new VacacionesPendientesDeAprobacion(juan, primero_de_febrero(), cinco_de_febrero()) };

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);

            var vacaciones_solicitables_2002 = listado_solicitables.First();
            var vacaciones_solicitables_2003 = listado_solicitables.Last();

            Assert.AreEqual(2, listado_solicitables.Count());
            Assert.AreEqual(2002, vacaciones_solicitables_2002.Periodo());
            Assert.AreEqual(0, vacaciones_solicitables_2002.CantidadDeDias());
            Assert.AreEqual(2003, vacaciones_solicitables_2003.Periodo());
            Assert.AreEqual(12, vacaciones_solicitables_2003.CantidadDeDias());

        }


        public Persona juan { get; set; }

        public DateTime primero_de_febrero() { return new DateTime(2013, 02, 01); }
        public DateTime cinco_de_febrero() { return new DateTime(2013, 02, 05); }

        public DateTime primero_de_enero(){ return  new DateTime(2013,01,01); }
        public DateTime cinco_de_enero(){ return  new DateTime(2013,01,05) ;}

        public DateTime primero_de_marzo() { return new DateTime(2013, 03, 01); }
        public DateTime diez_de_marzo() { return new DateTime(2013, 03, 10); }

        public DateTime primero_de_abril() { return new DateTime(2013, 04, 01); }
        public DateTime veinte_de_abril() { return new DateTime(2013, 04, 20); }

        public CalculadorDeVacaciones calculador() { return new CalculadorDeVacaciones(TestObjects.RepoLicenciaMockeado()); }


    }
}
